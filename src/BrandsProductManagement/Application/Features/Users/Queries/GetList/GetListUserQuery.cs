

using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<GetListResponse<GetListUserListItemDto>>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public string CacheKey => $"GetListUserQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
        public bool BypassCache { get; }
        public TimeSpan? SlidingExpiration { get; }

        public string? CacheGroupKey => "GetUsers";
    }
}