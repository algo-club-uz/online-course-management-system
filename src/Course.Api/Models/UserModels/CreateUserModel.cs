using CommonFiles.Entities.Enums;
using Course.Api.Entities.Enums;

namespace Course.Api.Models.UserModels;

public class CreateUserModel
{
    public Guid UserId { get; set; }
    public required string Firstname { get; set; }
    public string? Lastname { get; set; }
    public required string Username { get; set; }
    public ERole UserRole { get; set; }
}