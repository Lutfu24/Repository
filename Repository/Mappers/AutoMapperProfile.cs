using AutoMapper;
using Repository.DTOs.ProductDtos;
using Repository.Models;

namespace Repository.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductGetResponseDto>().ReverseMap();
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
    }
}
