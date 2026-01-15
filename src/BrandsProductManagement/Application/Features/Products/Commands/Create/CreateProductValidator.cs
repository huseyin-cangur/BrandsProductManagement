
using FluentValidation;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {

            RuleFor(b => b.Name).NotEmpty().MinimumLength(2);

        }
    }
}