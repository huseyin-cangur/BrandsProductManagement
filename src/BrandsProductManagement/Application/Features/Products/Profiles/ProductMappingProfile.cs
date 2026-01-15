

using Application.Features.Products.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();
        }
    }
}