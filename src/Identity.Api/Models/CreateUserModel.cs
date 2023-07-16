using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Models;

public class CreateUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}