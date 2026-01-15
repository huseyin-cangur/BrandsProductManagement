

using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(
              predicate: b => b.Id == request.Id);

            category = _mapper.Map(request, category);

            category = await _categoryRepository.UpdateAsync(category);

            UpdateCategoryResponse response = _mapper.Map<UpdateCategoryResponse>(category);

            return response;
        }
    }
}