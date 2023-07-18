using Course.Api.Entities.Enums;

namespace Course.Api.Models.UserCourseModels;

public class UserCourseModel
{
    public Guid Id { get; set; }
    public EUserCourse EUserCourseStatus { get; set; }

    public Guid UserId { get; set; }

    public Guid CourseId { get; set; }
}