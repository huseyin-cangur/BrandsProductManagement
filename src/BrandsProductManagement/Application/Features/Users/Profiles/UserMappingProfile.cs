

using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<CreatedUserResponse, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserResponse, User>().ReverseMap();
            CreateMap<DeleteUserCommand, User>().ReverseMap();
            CreateMap<DeleteUserResponse, User>().ReverseMap();


            CreateMap<User, GetListUserListItemDto>()
             .ForMember(
                dest => dest.OperationClaimIds,
                opt => opt.MapFrom(src =>
                    src.UserOperationClaims
                        .Select(x => x.OperationClaimId)
                        .ToList()
                )
            )
            .ReverseMap();

            CreateMap<Paginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
        }
    }
}