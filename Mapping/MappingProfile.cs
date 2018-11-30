using AutoMapper;
using vega.DTOs;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeDto>();
            CreateMap<Model, ModelDto>();
        }
    }
}