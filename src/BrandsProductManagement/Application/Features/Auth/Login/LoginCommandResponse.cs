

using Core.Security.JWT;

namespace Application.Features.Login
{
    public class LoginCommandResponse
    {
        public AccessToken AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;

   
        public Guid UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}