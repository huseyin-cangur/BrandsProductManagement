
using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand:IRequest<DeleteProductResponse>
    {
        public Guid Id { get; set; }
    }
}