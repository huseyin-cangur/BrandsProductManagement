
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryListItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {

            Paginate<Category> categories;


            if (request.PageRequest?.PageIndex.HasValue == true &&
                request.PageRequest.PageSize.HasValue)
            {
                categories = await _categoryRepository.GetListAsync(
                    index: request.PageRequest.PageIndex.Value,
                    size: request.PageRequest.PageSize.Value,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                categories = await _categoryRepository.GetListAsync(
                    cancellationToken: cancellationToken
                );
            }

            return _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(categories);



        }
    }
}