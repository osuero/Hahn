using AutoMapper;
using Hahn_OctavioSueroBackEnd.Application.Dto;
using Hahn_OctavioSueroBackEnd.Core.Entities;

namespace Hahn_OctavioSueroBackEnd.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
        } 
    }
}
