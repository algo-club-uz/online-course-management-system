using Course.Api.Context;
using Course.Api.Exception;
using Microsoft.EntityFrameworkCore;

namespace Course.Api.Repositories;

public interface ICourseRepository
{
    Task<List<Entities.Course>> GetCourses();

    Task AddCourse( Entities.Course course);

    Task<Entities.Course> GetCourseById( Guid courseId);

    Task UpdateCourse( Entities.Course course);

    Task DeleteCourse( Guid courseId);


}

public class CourseRepository: ICourseRepository
{
    private readonly CourseDbContext _context;

    public CourseRepository(CourseDbContext context)
    {
        _context = context;
    }

    public async Task<List<Entities.Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task AddCourse(Entities.Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.Course> GetCourseById(Guid courseId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
        if (course == null)
        {
            throw new CourseNotFoundException(courseId.ToString());
        }
        return course;
    }

    public async Task UpdateCourse( Entities.Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourse(Guid courseId)
    {
        var course = await GetCourseById(courseId);
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    
}


/*
    GET    courses
    POST   courses
    GET    courses/{ course_id}
    PUT    courses/{ course_id}
    DELETE courses/{ course_id}
*/