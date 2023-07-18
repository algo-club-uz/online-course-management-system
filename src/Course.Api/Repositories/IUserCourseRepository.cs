using Course.Api.Context;
using Course.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course.Api.Repositories;

public interface IUserCourseRepository
{
    Task<List<UserCourse>> GetUserCourses(Guid userId, Guid courseId);

    Task AddUserCourse(UserCourse userCourse);

    Task<UserCourse> GetUserCourseById (Guid userId, Guid courseId);

    Task UpdateUserCourse(UserCourse userCourse);

    Task DeleteUserCourse(Guid userId,Guid courseId);
}

public class UserCourseRepository : IUserCourseRepository
{
    private readonly CourseDbContext _context;

    public UserCourseRepository(CourseDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserCourse>> GetUserCourses(Guid userId, Guid courseId)
    {
        return await _context.UserCourses.Where(u => u.UserId == userId && u.CourseId == courseId).ToListAsync();
    }

    public async Task AddUserCourse(UserCourse userCourse)
    {
        _context.UserCourses.Add(userCourse);
        await _context.SaveChangesAsync();
    }

    public async Task<UserCourse> GetUserCourseById(Guid userId, Guid courseId)
    {
        var userCourse =
            await _context.UserCourses.FirstOrDefaultAsync(u => u.UserId == userId && u.CourseId == courseId);
        if (userCourse == null) throw new System.Exception("Not Found");
        return userCourse;
    }

    public async Task UpdateUserCourse(UserCourse userCourse)
    {
        _context.UserCourses.Update(userCourse);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserCourse(Guid userId, Guid courseId)
    {
        var userCourse = await GetUserCourseById(userId, courseId);
        _context.UserCourses.Remove(userCourse);
        await _context.SaveChangesAsync();
    }
}

/*
   
      GET    users/{user_id}/courses/{course_id}/user_courses
      POST   users/{user_id}/courses/{course_id}/user_courses
      GET    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
      PUT    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
      DELETE users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
 */