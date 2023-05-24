
using Application.Models.JWT;
using Domain.Entities;

namespace Application.interfaces.Authorization;

public interface IJWTTokenService
{
    JwtToken Authenticate(User user);
    string GetClaim(string token, string claimName);
}
