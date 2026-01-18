

using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

            user = await _userRepository.DeleteAsync(user);

            DeleteUserResponse response = _mapper.Map<DeleteUserResponse>(user);

            return response;
        }
    }
}