

using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>,ITransactionRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }

    }
}