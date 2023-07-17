using Course.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course.Api.Context;

public class CourseDbContext:DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users  {get;set;}
    public DbSet<UserCourse> UserCourses  {get;set;}
    public DbSet<Entities.Course> Courses  {get;set;}
    public DbSet<Content> Contents  {get;set;}
    public DbSet<Data> Data { get; set;}

}