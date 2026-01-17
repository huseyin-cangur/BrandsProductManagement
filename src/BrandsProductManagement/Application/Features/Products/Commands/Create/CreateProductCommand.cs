

using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>, ITransactionRequest, ICacheRemoverRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetProducts";



    }
}