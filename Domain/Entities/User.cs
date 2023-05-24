namespace Domain.Entities;
public sealed class User : Entity<UserId>
{
    private readonly HashSet<BoxSaving> _boxSavings = new();
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public UserInformation userInformation { get; private set; }
    public IReadOnlyCollection<BoxSaving> BoxSavings => _boxSavings;
    public User() {}
    public User(string password,string username, string email, UserId id) : base()
    {
        Id = id;
        this.UserName = username;
        this.Password = password;
        this.Email = email;
    }

    public static User Create(string username, string password, string email)
    {
        return new User(password, username, email, new UserId(Guid.NewGuid()));
    }
    public void AddUserInformation(string firstName, string lastName, string address, string phoneNumber)
    {
        userInformation = UserInformation.Create(firstName, lastName, address, phoneNumber, Id);
    }
    public void AddBoxSaving(int multiplier)
    {
        var boxSaving = BoxSaving.Create(Id, new BoxSavingId(Guid.NewGuid()), multiplier);

        _boxSavings.Add(boxSaving);
    }
    public void UpdateBoxSavings(int multiplier, BoxSavingId savingId, IEnumerable<Saving> savings)
    {
        var box = _boxSavings.FirstOrDefault(x => x.Id == savingId);

        if(box is null)
        {
            throw new Exception();
        }
        if (box.Multiplier != multiplier)
        {
            throw new Exception();
        }
        box.UpdateSaving(savings);
    }
}
