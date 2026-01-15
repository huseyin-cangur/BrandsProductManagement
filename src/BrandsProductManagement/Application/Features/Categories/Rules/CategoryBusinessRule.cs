

using Application.Features.Categories.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRule
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRule(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameCannotBeDuplicatetedWhenInserted(string name)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

            if (category != null)
            {
                throw new BusinessException(CategoryMessages.CategoryNameExists);
            }
        }

    }
}