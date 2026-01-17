
using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Application.Response;
using MediatR;

namespace Application.Features.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public string CacheKey => $"GetListProductQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
        public bool BypassCache { get; }
        public TimeSpan? SlidingExpiration { get; }

        public string? CacheGroupKey => "GetProducts";

    }
}