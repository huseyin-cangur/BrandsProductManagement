

using System.Linq.Dynamic.Core;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, GetListProductListItemDto>()
            .ForMember(destinationMember: c => c.CategoryName, memberOptions: opt => opt.MapFrom(c => c.Category.Name))
            .ReverseMap();

            CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();


            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();
            CreateMap<Product, DeleteProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductResponse>().ReverseMap();
        }
    }
}