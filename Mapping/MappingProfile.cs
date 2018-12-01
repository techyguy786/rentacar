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
            CreateMap<Model, ModelDto>();
            CreateMap<Feature, FeatureDto>();

            // API to Domain
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vd => vd.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vd => vd.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vd => vd.Contact.Phone))
                // VehicleFeatures is domain class & Features is int array. So we need to
                // convert it into domain type
                .ForMember(v => v.VehicleFeatures, opt => opt.MapFrom(vd => vd.Features
                    .Select(id => new VehicleFeature {
                        FeatureId = id
                    })));
        }
    }
}