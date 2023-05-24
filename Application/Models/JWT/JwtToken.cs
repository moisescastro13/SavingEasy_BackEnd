
namespace Application.Models.JWT;

public class JwtToken
{
    private JwtToken(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
    public static JwtToken Create(string token, string refreshToken)
    {
        return new JwtToken(token, refreshToken);
    }
    public string Token { get; private set; }
    public string RefreshToken { get; private set; }

}
