using Course.Api.Entities.Enums;
using Course.Api.Entities;
using Course.Api.Models.ContentModels;

namespace Course.Api.Models.CourseModels;

public class CourseModel
{
    public Guid CourseId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Price { get; set; }
    public ECourseStatus CourseStatus { get; set; }
    public DateTime CreateTime { get; set; }

    public  required List<ContentModel> Contents { get; set; }

    public  List<UserCourse>? UserCourses { get; set; }
}