

using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User? users = await _userRepository.GetAsync(
              predicate: b => b.Id == request.Id,
               cancellationToken: cancellationToken);

            GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(users);

            return response;
        }
    }
}