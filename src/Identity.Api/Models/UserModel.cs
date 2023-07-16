using Identity.Api.Entities;

namespace Identity.Api.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string UserName { get; set; }

    public UserModel(User user)
    {
        Id = user.UserId;
        Name = user.Firstname;
        UserName = user.Username;
    }
}