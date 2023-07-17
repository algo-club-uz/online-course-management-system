using Identity.Api.Context;
using Identity.Api.Entities;
using Identity.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Repositories;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User> GetUserByUserName(string username);
    Task<User> GetUserById(Guid userId);
    Task<bool> IsUserNameExist(string userName);
}

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task AddUser(User user)
    {
        await _identityDbContext.Users.AddAsync(user);
        await _identityDbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByUserName(string username)
    {
        var user = await _identityDbContext.Users.FirstOrDefaultAsync(i => i.Username == username);
        if (user == null)
        {
            throw new UserNotFoundException(username);
        }
        return user;
    }

    public async Task<User> GetUserById(Guid userId)
    {
        var user = await _identityDbContext.Users.FirstOrDefaultAsync(i => i.UserId == userId);
        if (user == null)
        {
            throw new UserNotFoundException(userId.ToString());
        }

        return user;
    }

    public async Task<bool> IsUserNameExist(string userName)
    {
        var isExists = await _identityDbContext.Users.
            Where(i => i.Username == userName).AnyAsync();
        return isExists;
    }
}