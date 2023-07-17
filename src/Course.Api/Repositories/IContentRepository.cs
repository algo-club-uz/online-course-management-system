using Course.Api.Context;
using Course.Api.Entities;
using Course.Api.Exception;

namespace Course.Api.Repositories;

public interface IContentRepository
{
    Task<List<Content>?> GetContents(Guid courseId);

    Task AddContent(Content content);

    Task<Content> GetContentById(Guid courseId, Guid contentId);

    Task UpdateContent(Content content);

    Task DeleteContent(Guid courseId, Guid contentId);
}

public class ContentRepository : IContentRepository
{
    private readonly CourseDbContext _context;
    private readonly ICourseRepository _courseRepository;

    public ContentRepository(CourseDbContext context, ICourseRepository courseRepository)
    {
        _context = context;
        _courseRepository = courseRepository;
    }

    public async Task<List<Content>?> GetContents(Guid courseId)
    {
        var course = await _courseRepository.GetCourseById(courseId);
        if (course.Contents != null) return course.Contents.ToList();
        return null;
    }

    public async Task AddContent(Content content)
    {
        var course = await _courseRepository.GetCourseById(content.CourseId);
        _context.Contents.Add(content);
        await  _context.SaveChangesAsync();
    }

    public async Task<Content> GetContentById(Guid courseId, Guid contentId)
    {
        var course = await _courseRepository.GetCourseById(courseId);
        if (course.Contents != null)
        {
            var content = course.Contents.FirstOrDefault(c => c.ContentId == contentId);
            if (content != null)
            {
                return content;
            }
            else
            {
                throw new ContentNotFoundException(contentId.ToString());
            }
        }
        else
        {
            throw new ContentNullException("Content is null");
        }
    }

    public async Task UpdateContent(Content content)
    {
        var course = await _courseRepository.GetCourseById(content.CourseId);
        _context.Contents.Update(content);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContent(Guid courseId, Guid contentId)
    {
        var content = await GetContentById(courseId, contentId);
        _context.Contents.Remove(content);
        await _context.SaveChangesAsync();
    }
    
    
}


/*
    GET    courses/{course_id}/contents
    POST   courses/{course_id}/contents
    GET    courses/{course_id}/contents/{content_id}
    PUT    courses/{course_id}/contents/{content_id}
    DELETE courses/{course_id}/contents/{content_id}
 */