using Course.Api.Managers;
using Course.Api.Models.CourseModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly CourseManager _courseManager;

    public CoursesController(CourseManager courseManager)
    {
        _courseManager = courseManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseManager.GetCourses();

        return Ok(courses);
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(CreateCourseModel model)
    {
        return Ok(await _courseManager.AddCourse(model));
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseById(Guid courseId)
    {
        return Ok(await _courseManager.GetCourseById(courseId) );
    }

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseById(Guid courseId,CreateCourseModel model)
    {
        return Ok(await _courseManager.UpdateCourse(courseId,model));
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourseById(Guid courseId)
    {
        return Ok(await _courseManager.DeleteCourse(courseId));
    }
}