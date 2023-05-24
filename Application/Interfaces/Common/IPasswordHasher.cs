

namespace Application.Interfaces.Common;

public interface IPasswordHasher
{
    public string Hash(string password);

    public bool Verify(string password, string passwordHash);
}
