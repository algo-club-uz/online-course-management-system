using Course.Api.Entities;
using Course.Api.Models.UserCourseModels;
using Course.Api.Repositories;
using Course.Api.Services;

namespace Course.Api.Managers;

public class UserCourseManager
{
    private readonly IUserCourseRepository _userCourseRepository;
    private readonly ParseService _parseService;

    public UserCourseManager(IUserCourseRepository userCourseRepository, ParseService parseService)
    {
        _userCourseRepository = userCourseRepository;
        _parseService = parseService;
    }

    public async Task<List<UserCourseModel>?> GetUserCourses(Guid userId, Guid courseId)
    {
        var userCourses = await _userCourseRepository.GetUserCourses(userId, courseId);
        return _parseService.ParseListModel(userCourses);
    }

    public async Task<UserCourseModel> AddUserCourse(Guid userId, Guid courseId, CreateUserCourseModel model)
    {
        var userCourse = new UserCourse()
        {
            UserId = userId,
            CourseId = courseId,
            EUserCourseStatus = model.EUserCourseStatus
        };

        await _userCourseRepository.AddUserCourse(userCourse);

        return _parseService.ParseModel(userCourse);
    }

    public async Task<UserCourseModel> GetUserCourseById(Guid userId, Guid courseId)
    {
        var userCourse = await _userCourseRepository.GetUserCourseById(userId, courseId);
        return _parseService.ParseModel(userCourse);
    }

    public async Task<UserCourseModel> UpdateUserCourse(Guid userId, Guid courseId, CreateUserCourseModel model)
    {
        var userCourse = await _userCourseRepository.GetUserCourseById(userId, courseId);
        userCourse.EUserCourseStatus = model.EUserCourseStatus;
        await _userCourseRepository.UpdateUserCourse(userCourse);
        return _parseService.ParseModel(userCourse);
    }

    public async Task<string> DeletedUserCourse(Guid userId, Guid courseId)
    {
        await _userCourseRepository.DeleteUserCourse(userId, courseId);
        return "Deleted";
    }
}

/*
   
      GET    users/{user_id}/courses/{course_id}/user_courses
      POST   users/{user_id}/courses/{course_id}/user_courses
      GET    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
      PUT    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
      DELETE users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
 */