

using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Hashing;

namespace Application.Features.Login.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        public void PasswordMustBeCorrect(
       string password,
       byte[] passwordHash,
       byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(
                    password,
                    passwordHash,
                    passwordSalt))
            {
                throw new BusinessException("Şifre hatalı");
            }
        }
    }
}