

using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



    }
}