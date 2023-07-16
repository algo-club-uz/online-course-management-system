﻿using Identity.Api.Context;
using Identity.Api.Entities;
using Identity.Api.Entities.Enums;
using Identity.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Managers;

public class UserManager
{
    private readonly IdentityDbContext _context;
    private ILogger<UserManager> _logger;
    private readonly JwtTokenManager _jwtTokenManager;

    public UserManager(IdentityDbContext context, ILogger<UserManager> logger, JwtTokenManager jwtTokenManager)
    {
        _context = context;
        _logger = logger;
        _jwtTokenManager = jwtTokenManager;
    }


    public async Task<User> Register(CreateUserModel model)
    {
        if (await _context.Users.AnyAsync(u => u.Username == model.Username))
        {
            throw new Exception("Username already exists");
        }

        var user = new User()
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Username = model.Username,
            UserRole = ERole.User
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<string> Login(LoginUserModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
        if (user == null)
        {
            throw new Exception("Username or Password is incorrect");
        }

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Username or Password is incorrect");
        }

        var token = _jwtTokenManager.GenerateToken(user);

        return token;
    }

    public async Task<User?> GetUser(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
    public async Task<User?> GetUser(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    }

}