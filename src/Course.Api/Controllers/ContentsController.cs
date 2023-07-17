using Course.Api.Models.ContentModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/[controller]")]
[ApiController]
public class ContentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetContents()
    {
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> AddContent(CreateContentModel model)
    {
        return Ok();
    }  
    [HttpGet("{contentId}")]
    public async Task<IActionResult> GetContentById(Guid contentId)
    {
        return Ok();
    }  
    [HttpDelete("{contentId}")]
    public async Task<IActionResult> DeleteContentById(Guid contentId)
    {
        return Ok();
    }
    [HttpPut("{contentId}")]
    public async Task<IActionResult> UpdateContentById(Guid contentId)
    {
        return Ok();
    }
}