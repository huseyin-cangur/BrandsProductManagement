
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            Category? category = await _categoryRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

            category = await _categoryRepository.DeleteAsync(category);

            DeleteCategoryResponse response = _mapper.Map<DeleteCategoryResponse>(category);

            return response;
        }
    }
}