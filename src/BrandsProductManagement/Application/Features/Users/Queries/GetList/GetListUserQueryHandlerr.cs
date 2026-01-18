

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

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

            Paginate<User> users;


            if (request.PageRequest?.PageIndex.HasValue == true &&
                request.PageRequest.PageSize.HasValue)
            {
                users = await _userRepository.GetListAsync(
                    index: request.PageRequest.PageIndex.Value,
                    size: request.PageRequest.PageSize.Value,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                users = await _userRepository.GetListAsync(
                    cancellationToken: cancellationToken
                );
            }

            return _mapper.Map<GetListResponse<GetListUserListItemDto>>(users);
        }
    }
}