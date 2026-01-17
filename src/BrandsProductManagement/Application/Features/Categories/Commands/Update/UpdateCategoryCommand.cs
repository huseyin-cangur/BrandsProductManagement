
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryResponse>,ITransactionRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}