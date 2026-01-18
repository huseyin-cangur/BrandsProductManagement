

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Claims.Queries.GetList
{
    public class GetListCliamQueryHandler : IRequestHandler<GetListClaimQuery, GetListResponse<GetListClaimItemDto>>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListCliamQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }


        public async Task<GetListResponse<GetListClaimItemDto>> Handle(GetListClaimQuery request, CancellationToken cancellationToken)
        {
            Paginate<OperationClaim> claims = await _operationClaimRepository.GetListAsync(
                 cancellationToken: cancellationToken);


            return _mapper.Map<GetListResponse<GetListClaimItemDto>>(claims);
        }
    }
}