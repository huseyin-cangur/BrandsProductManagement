
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }


        public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);
            User user = _mapper.Map<User>(request);

            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            User createdUser = await _userRepository.AddAsync(user);


            if (request.OperationClaimIds is not null && request.OperationClaimIds.Any())
            {
                List<UserOperationClaim> userOperationClaims =
                    request.OperationClaimIds.Select(operationId => new UserOperationClaim
                    {
                        UserId = createdUser.Id,
                        OperationClaimId=operationId
                    }
                      
                   ).ToList();

                await _userOperationClaimRepository.AddRangeAsync(userOperationClaims);
            }



            CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);
            response.OperationClaimIds = request.OperationClaimIds;
            return response;
        }
    }
}