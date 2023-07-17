using Course.Api.Models.ContentModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/[controller]")]
[ApiController]
public class ContentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetContents(Guid courseId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddContent(Guid courseId,CreateContentModel model)
    {
        return Ok();
    }  

    [HttpGet("{contentId}")]
    public async Task<IActionResult> GetContentById(Guid courseId,Guid contentId)
    {
        return Ok();
    }  

    [HttpDelete("{contentId}")]
    public async Task<IActionResult> DeleteContentById(Guid courseId,Guid contentId)
    {
        return Ok();
    }

    [HttpPut("{contentId}")]
    public async Task<IActionResult> UpdateContentById(Guid courseId,Guid contentId)
    {
        return Ok();
    }
}