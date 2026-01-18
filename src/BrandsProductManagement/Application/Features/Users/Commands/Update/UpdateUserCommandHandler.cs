
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }



        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(
       u => u.Id == request.Id,
            include: u => u.Include(x => x.UserOperationClaims)
        );



            user = _mapper.Map(request, user);

            user = await _userRepository.UpdateAsync(user);

            await SyncUserOperationClaimsAsync(user, request.OperationClaimIds);

            UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
            response.OperationClaimIds = request.OperationClaimIds;

            return response;
        }

        private async Task SyncUserOperationClaimsAsync(
  User user,
  List<Guid>? newOperationClaimIds)
        {
            var currentClaimIds = user.UserOperationClaims
                .Select(x => x.OperationClaimId)
                .ToList();

            var newClaimIds = newOperationClaimIds?
                .Distinct()
                .ToList()
                ?? new List<Guid>();


            var claimsToRemove = user.UserOperationClaims
                .Where(x => !newClaimIds.Contains(x.OperationClaimId))
                .ToList();

            if (claimsToRemove.Any())
            {
                await _userOperationClaimRepository
                    .DeleteRangeAsync(claimsToRemove);
            }


            var claimsToAdd = newClaimIds
                .Where(id => !currentClaimIds.Contains(id))
                .Select(id => new UserOperationClaim
                {
                    UserId = user.Id,
                    OperationClaimId = id
                })
                .ToList();

            if (claimsToAdd.Any())
            {
                await _userOperationClaimRepository
                    .AddRangeAsync(claimsToAdd);
            }
        }
    }


}



