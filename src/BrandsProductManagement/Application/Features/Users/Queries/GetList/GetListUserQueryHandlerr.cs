

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQueryHandlerr : IRequestHandler<GetListUserQuery, GetListResponse<GetListUserListItemDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandlerr(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetListResponse<GetListUserListItemDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {

            Paginate<User> users = await _userRepository.GetListAsync(
                    include:u=>u.Include(u=>u.UserOperationClaims).ThenInclude(o=>o.OperationClaim),
                    index: request.PageRequest.PageIndex.Value,
                    size: request.PageRequest.PageSize.Value,
                    cancellationToken: cancellationToken);


            return _mapper.Map<GetListResponse<GetListUserListItemDto>>(users);
        }
    }
}