

using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetUsers";
    }
}