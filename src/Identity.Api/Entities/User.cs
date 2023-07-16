using Identity.Api.Entities.Enums;

namespace Identity.Api.Entities;

public class User
{ 
    public Guid UserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public DateTime CreateDate { get; set; }
    public ERole UserRole { get; set; }
}