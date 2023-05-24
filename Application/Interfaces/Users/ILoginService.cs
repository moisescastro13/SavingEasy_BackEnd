
using Application.Dto.User;
using Application.Models.JWT;

namespace Application.Interfaces.Users
{
    public interface ILoginService
    {
        Task<JwtToken> Authenticate(AuthenticationDto authenticationDto, CancellationToken cancellationToken);
    }
}
