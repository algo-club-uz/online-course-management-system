using Course.Api.Context;
using Course.Api.Managers;
using Course.Api.Repositories;
using Course.Api.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Course.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); builder.Services.AddMassTransit(c =>
{
    c.AddConsumers(Assembly.GetEntryAssembly());
    c.UsingRabbitMq(
        (context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);
        }
    );

});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();

//Managers
builder.Services.AddScoped<ParseService>();
builder.Services.AddScoped<CourseManager>();
builder.Services.AddScoped<ContentManager>();
builder.Services.AddScoped<DataManager>();
builder.Services.AddScoped<UserCourseManager>();

builder.Services.AddDbContext<CourseDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDb"));
});
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.MigrateCourseDb();
//app.UseStaticFiles("Files");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
