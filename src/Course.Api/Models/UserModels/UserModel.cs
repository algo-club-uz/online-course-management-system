using CommonFiles.Entities.Enums;
using Course.Api.Models.UserCourseModels;

namespace Course.Api.Models.UserModels;

public class UserModel
{
    public Guid UserId { get; set; }
    public required string Firstname { get; set; }
    public string? Lastname { get; set; }
    public required string Username { get; set; }
    public ERole UserRole { get; set; }

    public virtual List<UserCourseModel>? UserCourses { get; set; }
}