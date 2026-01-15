

using MediatR;

namespace Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResponse>
    {
        public Guid Id { get; set; }
    }
}