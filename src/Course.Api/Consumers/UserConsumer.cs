using Course.Api.Context;
using Course.Api.Entities;
using MassTransit;

namespace Course.Api.Consumers;

public class UserConsumer:IConsumer<User>
{
    private readonly CourseDbContext _context;

    public UserConsumer(CourseDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
        var user = context.Message;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();


    }
}