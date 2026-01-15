
using MediatR;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryResponse>
    {
        public Guid Id { get; set; }
    }
}