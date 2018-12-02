using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using vega.DTOs;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API
            CreateMap<Make, MakeDto>();
            CreateMap<Make, KeyValuePairDto>();
            CreateMap<Model, KeyValuePairDto>();
            CreateMap<Feature, KeyValuePairDto>();
            CreateMap<Vehicle, SaveVehicleDto>()
                .ForMember(vd => vd.Contact, opt => opt.MapFrom(v => new ContactDto {
                    Name = v.ContactName,
                    Email = v.ContactEmail,
                    Phone = v.ContactPhone
                }))
                .ForMember(vd => vd.Features, opt => opt.MapFrom(v => 
                    v.VehicleFeatures.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(vd => vd.Make, opt => opt.MapFrom(v => v.Model.Make))
                .ForMember(vd => vd.Contact, opt => opt.MapFrom(v => new ContactDto {
                    Name = v.ContactName,
                    Email = v.ContactEmail,
                    Phone = v.ContactPhone
                }))
                .ForMember(vd => vd.Features, opt => opt.MapFrom(v => 
                    v.VehicleFeatures.Select(vf => new KeyValuePairDto 
                    { 
                        Id = vf.Feature.FeatureId,
                        Name = vf.Feature.Name
                    })));


            // API to Domain
            CreateMap<SaveVehicleDto, Vehicle>()
                .ForMember(v => v.VehicleId, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vd => vd.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vd => vd.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vd => vd.Contact.Phone))
                .ForMember(v => v.VehicleFeatures, opt => opt.Ignore())
                .AfterMap((vd, v) => {
                    // Remove Unselected Features
                    var removedFeatures = new List<VehicleFeature>();
                    foreach (var f in v.VehicleFeatures)
                        if (!vd.Features.Contains(f.FeatureId))
                            removedFeatures.Add(f);
                    foreach (var f in removedFeatures)
                        v.VehicleFeatures.Remove(f);

                    // Add new features
                    foreach (var id in vd.Features)
                        if (!v.VehicleFeatures.Any(f => f.FeatureId == id))
                            v.VehicleFeatures.Add(new VehicleFeature {
                                FeatureId = id
                            });
                });
        }
    }
}