
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
            Paginate<Category> Categories = await _categoryRepository.GetListAsync(
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken

           );

            GetListResponse<GetListCategoryListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(Categories);

            return getListResponse;
        }
    }
}