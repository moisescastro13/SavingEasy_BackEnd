
namespace Application.Dto.User;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public CreateUserInformationDto informationDto { get; set; }
}
