using Course.Api.Entities.Enums;

namespace Course.Api.Entities;

public class UserCourse
{
    public Guid Id { get; set; }
    public EUserCourse EUserCourseStatus { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    public Guid CourseId { get; set; }
    public virtual Course? Course { get; set; }
}