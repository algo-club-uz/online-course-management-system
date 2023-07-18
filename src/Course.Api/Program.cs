using Course.Api.Context;
using Course.Api.Managers;
using Course.Api.Repositories;
using Course.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

//Managers
builder.Services.AddScoped<ParseService>();
builder.Services.AddScoped<ContentManager>();

builder.Services.AddDbContext<CourseDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDb"));
});
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseStaticFiles("Files");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
