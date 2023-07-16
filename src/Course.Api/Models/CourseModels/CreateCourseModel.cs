using Course.Api.Entities.Enums;

namespace Course.Api.Models.CourseModels;

public class CreateCourseModel
{ 
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Price { get; set; }
    public ECourseStatus CourseStatus { get; set; }
}