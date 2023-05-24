
using Application.interfaces.Authorization;
using Application.Models.JWT;
using Domain.Entities;
using Infrastructure.JWT.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.JWT.Services;

public class JwtServiceManage : IJWTTokenService
{
    private readonly JwtOptions _options;

    public JwtServiceManage(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public JwtToken Authenticate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_options.SecretKey);
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
           {
               new Claim(ClaimTypes.NameIdentifier, user.Id.value.ToString()),
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Email, user.Email),
           }),
            
           Expires = DateTime.UtcNow.AddMinutes(5),
           SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return JwtToken.Create(tokenHandler.WriteToken(token), "");
    }
    public string GetClaim(string token, string claimName)
    {
        const string Bearer = "Bearer ";

        token = token.Replace(Bearer, "");
        var handler = new JwtSecurityTokenHandler();

        var claims = handler.ReadJwtToken(token);
        return claims.Claims.First(x => x.Type.Equals(claimName)).Value;
    }

}
