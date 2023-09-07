using Course.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Course.Api.Extensions;

public static  class ServiceCollectionExtensions
{


    /*public static void MigrateCourseDb(this WebApplication app)
    {
        if (app.Services.GetService<CourseDbContext>() != null)
        {
            var courseDb = app.Services.GetRequiredService<CourseDbContext>();
            courseDb.Database.Migrate();
        }
    }*/
    public static void MigrateCourseDb(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var courseDb = services.GetService<CourseDbContext>();

            if (courseDb != null)
            {
                courseDb.Database.Migrate();
            }
        }
    }
}