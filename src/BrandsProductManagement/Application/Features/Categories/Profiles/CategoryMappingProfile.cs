

using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        protected CategoryMappingProfile()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<CreatedCategoryResponse, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryResponse, Category>().ReverseMap();
            CreateMap<DeleteCategoryCommand, Category>().ReverseMap();
            CreateMap<DeleteCategoryResponse, Category>().ReverseMap();


            CreateMap<Category, GetListCategoryListItemDto>().ReverseMap();

            CreateMap<Paginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();




        }


    }
}