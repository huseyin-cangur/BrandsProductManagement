
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public List<Guid> OperationClaimIds { get; set; }

    }
}