

using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<GetByIdUserResponse>
    {
        public Guid Id { get; set; }
    }
}