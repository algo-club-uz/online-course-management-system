using CommonFiles.Models.CommonModels;
using Course.Api.Context;
using Course.Api.Entities;
using MassTransit;

namespace Course.Api.Consumers;

public class UserConsumer:IConsumer<UserModel>
{
    private readonly CourseDbContext _context;

    public UserConsumer(CourseDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<UserModel> context)
    {
        var userModel = context.Message;
        var user = new User()
        {
            UserId = userModel.UserId,
            Firstname = userModel.Firstname,
            Lastname = userModel.Lastname,
            Username = userModel.Username,
            UserRole = userModel.UserRole
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}