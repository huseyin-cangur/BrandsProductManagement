
using Application.Features.Login.Rules;
using Application.Services.Repositories;
using Core.Application.Extensions;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetAsync(u => u.Email == request.Email);

            if (user == null)
                throw new BusinessException("Kullanıcı bulunamadı");


            _authBusinessRules.PasswordMustBeCorrect(
            request.Password,
            user.PasswordHash,
            user.PasswordSalt);

            IList<OperationClaim> claims =
           await _userOperationClaimRepository.GetOperationClaimsByUserIdAsync(user.Id);

            AccessToken accessToken =
             _tokenHelper.CreateToken(user, claims);

             string ipAddress = _httpContextAccessor.HttpContext.GetIpAddress();

            RefreshToken refreshToken =
                _tokenHelper.CreateRefreshToken(user, ipAddress);

            await _refreshTokenRepository.AddAsync(refreshToken);

            return new LoginCommandResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,

                UserId = user.Id,
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Roles = claims.Select(c => c.Name).ToList()
            };





        }
    }
}