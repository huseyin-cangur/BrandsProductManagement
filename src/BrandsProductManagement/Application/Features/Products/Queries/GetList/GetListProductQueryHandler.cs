
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetList
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products;

            if (request.PageRequest?.PageIndex.HasValue == true &&
                request.PageRequest.PageSize.HasValue)
            {
                products = await _productRepository.GetListAsync(
                    include: p => p.Include(p => p.Category),
                    index: request.PageRequest.PageIndex.Value,
                    size: request.PageRequest.PageSize.Value,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                products = await _productRepository.GetListAsync(
                    include: p => p.Include(p => p.Category),
                    cancellationToken: cancellationToken
                );
            }
            return _mapper.Map<GetListResponse<GetListProductListItemDto>>(products);

        }
    }
}