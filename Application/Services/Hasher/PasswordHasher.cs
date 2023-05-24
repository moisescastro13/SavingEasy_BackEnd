using Application.Interfaces.Common;

namespace Application.Services.Hasher;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 13);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        var isValidPassword = BCrypt.Net.BCrypt.Verify(password, passwordHash);

        return isValidPassword;
    }
}
