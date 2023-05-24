using Application.Dto.User;

namespace Application.Interfaces.Users;

public interface IUserRegisterService
{
    Task<ReadUserDto?> Register(CreateUserDto createUserDto, CancellationToken cancellationToken);
}
