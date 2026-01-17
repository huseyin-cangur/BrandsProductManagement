
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetProducts";
    }
}