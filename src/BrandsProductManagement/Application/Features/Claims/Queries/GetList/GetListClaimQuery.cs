

using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Claims.Queries.GetList
{
    public class GetListClaimQuery : IRequest<GetListResponse<GetListClaimItemDto>>
    {
       public PageRequest PageRequest {get;set;}
    }
}