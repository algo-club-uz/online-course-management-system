﻿using CommonFiles.Entities.Enums;

namespace CommonFiles.Models.CommonModels;

public class UserModel
{
    public Guid UserId { get; set; }
    public  string Firstname { get; set; }
    public string? Lastname { get; set; }
    public  string Username { get; set; }
    public DateTime CreateDate { get; set; }
    public ERole UserRole { get; set; }


}