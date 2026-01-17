

using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetProducts";
    }
}