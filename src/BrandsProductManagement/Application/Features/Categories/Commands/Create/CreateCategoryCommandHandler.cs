

using Application.Features.Categories.Rules;
using Application.Features.Products.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRule _categoryBusinessRule;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRule categoryBusinessRule)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRule = categoryBusinessRule;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRule.CategoryNameCannotBeDuplicatetedWhenInserted(request.Name);

            Category category = _mapper.Map<Category>(request);
            category.Id = Guid.NewGuid();


            await _categoryRepository.AddAsync(category);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);

            

            return response;
        }
    }
}