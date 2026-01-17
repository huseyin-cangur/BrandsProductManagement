
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryResponse>, ITransactionRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetCategories";

    }
}