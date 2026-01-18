
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(
             predicate: b => b.Id == request.Id);

            user = _mapper.Map(request, user);

            user = await _userRepository.UpdateAsync(user);

            UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);

            return response;
        }
    }
}