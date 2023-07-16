using Course.Api.Entities.Enums;
using Course.Api.Models.CourseModels;

namespace Course.Api.Models;

public class UserCourseModel
{
    public Guid Id { get; set; }
    public EUserCourse EUserCourseStatus { get; set; }

    public Guid UserId { get; set; }
    public  User? User { get; set; }

    public Guid CourseId { get; set; }
    public  CourseModel? Course { get; set; }
}