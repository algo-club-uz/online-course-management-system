using Course.Api.Models.CourseModels;
using Course.Api.Repositories;
using Course.Api.Services;

namespace Course.Api.Managers;

public class CourseManager
{
    private readonly IUnitRepository _unitRepository;
    private readonly ParseService _parseService;
    public CourseManager(IUnitRepository unitRepository, ParseService parseService)
    {
        _unitRepository = unitRepository;
        _parseService = parseService;
    }

    public async Task<List<CourseModel>?> GetCourses()
    {
        var courses = await _unitRepository.Courses.GetCourses();
        return _parseService.ParseListModel(courses);
    }

    public async Task<CourseModel> AddCourse(CreateCourseModel model)
    {
        var course = new Entities.Course
        {
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
            CourseStatus = model.CourseStatus,
        };
        await _unitRepository.Courses.AddCourse(course);
        return _parseService.ParseModel(course);
    }

    public async Task<CourseModel> GetCourseById(Guid courseId)
    {
        return _parseService.ParseModel(await _unitRepository.Courses.GetCourseById(courseId));
    }

    public async Task<CourseModel> UpdateCourse(Guid courseId, CreateCourseModel model)
    {
        var course = await _unitRepository.Courses.GetCourseById(courseId);
        course.Title = model.Title;
        course.Description = model.Description;
        course.Price = model.Price;
        course.CourseStatus = model.CourseStatus;
        await _unitRepository.Courses.UpdateCourse(course);
        return _parseService.ParseModel(course);
    }

    public async Task<string> DeleteCourse(Guid courseId)
    {
        await _unitRepository.Courses.DeleteCourse(courseId);
        return "Deleted";
    }





} 

/*
    GET    courses
    POST   courses
    GET    courses/{course_id}
    PUT    courses/{course_id}
    DELETE courses/{course_id}
*/