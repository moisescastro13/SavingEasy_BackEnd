
namespace Domain.Entities;

public class UserInformation : Entity<UserInformationId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public User user { get; private set; }
    public UserId userId { get; private set; }
    public UserInformation() { }
    public UserInformation(string firstName, string lastName, string address, string phoneNumber, UserId userId, UserInformationId id) : base()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        this.userId = userId;
    }

    public static UserInformation Create(string firstName, string lastName, string address, string phoneNumber, UserId userId)
    {
        return new UserInformation(firstName, lastName, address, phoneNumber, userId, new UserInformationId(Guid.NewGuid()));
    }
}
