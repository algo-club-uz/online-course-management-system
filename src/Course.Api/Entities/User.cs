using Course.Api.Entities.Enums;

namespace Course.Api.Entities;

public class User
{ 
    public Guid UserId { get; set; }
    public required string Firstname { get; set; }
    public string? Lastname { get; set; }
    public required string Username { get; set; }
    public ERole UserRole { get; set; }

    public virtual List<UserCourse>? UserCourses { get; set; }
}