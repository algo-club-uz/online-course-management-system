using Course.Api.Models.CourseModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(CreateCourseModel model)
    {

        return Ok();
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseById(Guid courseId)
    {
        return Ok();
    }

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseById(Guid courseId)
    {
        return Ok();
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourseById(Guid courseId)
    {
        return Ok();
    }
}