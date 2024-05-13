namespace UnitTest.UserManagement_SampleApp.src;
internal class UserManagement
{
    private readonly List<User> _users = [];
    public IEnumerable<User> Users => _users;
    private int @count = 1;
    public void Add(User user) => _users.Add(user with { Id = @count++});
    public void UpdatePhone(User user) => _users.First(u => u.Id == user.Id).Phone = user.Phone;
    public void Verify(User user) => _users.First(u => u.Id == user.Id).Verified = true;

    public static void Main()
    {
        UserManagement t = new();
        t.Add(user: new("Alex", "Xela") { Id = 0, Email = "", CreatedDate = DateTime.MinValue });
    }
}
public record User(string FirstName, string LastName)
{
    public required int Id { get; set; }
    public required DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? Phone { get; set; }
    public required string Email { get; set; } = FirstName.ToLower().Trim() + "." + LastName.ToLower().Trim() + "@email.com";
    public bool Verified { get; set; } = false;
}
