
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreatedUserResponse>, ITransactionRequest, ICacheRemoverRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "GetUsers";
    }
}