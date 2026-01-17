

using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ITransactionRequest, ICacheRemoverRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetCategories";

    }
}