using Course.Api.Entities.Enums;

namespace Course.Api.Entities;

public class Course
{ 
    public Guid CourseId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Price { get; set; }
    public  ECourseStatus CourseStatus { get; set; }

    public DateTime CreateTime { get; set; } = DateTime.UtcNow;

    public virtual  List<Content>? Contents { get; set; }

    public virtual List<UserCourse>? UserCourses { get; set; }
}