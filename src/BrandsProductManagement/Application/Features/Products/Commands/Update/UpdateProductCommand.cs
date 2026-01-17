
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>,ITransactionRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }

    }
}