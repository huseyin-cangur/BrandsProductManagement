

using Application.Features.Claims.Queries.GetList;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Claims.Profiles
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<OperationClaim, GetListClaimResponse>();
           CreateMap<OperationClaim, GetListClaimItemDto>();


            CreateMap<Paginate<OperationClaim>, GetListResponse<GetListClaimItemDto>>().ReverseMap();

        }
    }
}