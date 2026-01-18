

using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>, ICachableRequest
    {
        public PageRequest? PageRequest { get; set; }
        public string CacheKey =>
          PageRequest is null
         ? "GetListCategoryQueryAll"
         : $"GetListCategoryQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
        public bool BypassCache { get; }
        public TimeSpan? SlidingExpiration { get; }

        public string? CacheGroupKey => "GetCategories";
    }
}