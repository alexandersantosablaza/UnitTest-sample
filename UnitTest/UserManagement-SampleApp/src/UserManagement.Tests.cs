namespace UnitTest.UserManagement_SampleApp.src;
public class UserManagementTests
{
    private readonly UserManagement _svc;
    public UserManagementTests()
    {
        _svc = new UserManagement();
    }
    [Fact]
    public void Method_Add_Insert_User()
    {
        //arrange
        const string s = "something";
        User user = new("Alex", "xelA")
        {
            Id = 1,
            Email = s,
            CreatedDate = DateTime.Now
        };
        //act
        _svc.Add(user);
        //assert
        var savedUser = Assert.Single(_svc.Users);
        Assert.True(_svc.Users.Any());
        Assert.Equal("Alex", savedUser.FirstName);
        Assert.Equal("xelA", savedUser.LastName);
        var props = typeof(User).GetProperties();
        foreach (var p in props)
        {
//            Console.WriteLine("{prop name} : {prop value}", f[i].GetValue(savedUser));
            Assert.Equal(p.GetValue(user, null), p.GetValue(savedUser, null));
        }
    }
}
