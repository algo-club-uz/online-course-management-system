﻿using Identity.Api.Entities;
using Identity.Api.Entities.Enums;

namespace Identity.Api.Models;

public class UserModel
{
    public Guid UserId { get; set; }
    public  string Firstname { get; set; }
    public string? Lastname { get; set; }
    public  string Username { get; set; }
    public DateTime CreateDate { get; set; }
    public ERole UserRole { get; set; }

    public UserModel(User user)
    {
        UserId = user.UserId;
        Firstname = user.Firstname;
        Lastname = user.Lastname;
        Username = user.Username;
        CreateDate = user.CreateDate;
        UserRole = user.UserRole;
    }
}