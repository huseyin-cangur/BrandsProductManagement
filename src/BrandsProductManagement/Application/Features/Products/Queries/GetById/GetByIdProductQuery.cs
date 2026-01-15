

using MediatR;

namespace Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
    {
        public Guid Id { get; set; }
    }
}