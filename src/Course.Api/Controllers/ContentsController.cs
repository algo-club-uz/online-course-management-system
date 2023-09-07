using Course.Api.Managers;
using Course.Api.Models.ContentModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/[controller]")]
[ApiController]
public class ContentsController : ControllerBase
{
    private readonly ContentManager _contentManager;

    public ContentsController(ContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetContents(Guid courseId)
    {
        var contents = await _contentManager.GetContents(courseId);

        return Ok(contents);
    }

    [HttpPost]
    public async Task<IActionResult> AddContent(Guid courseId,CreateContentModel model)
    {
        return Ok(await _contentManager.AddContent(courseId,model));
    }  

    [HttpGet("{contentId}")]
    public async Task<IActionResult> GetContentById(Guid courseId,Guid contentId)
    {
        return Ok(await _contentManager.GetContentById(courseId,contentId));
    }

    [HttpPut("{contentId}")]
    public async Task<IActionResult> UpdateContentById(Guid courseId, Guid contentId,CreateContentModel model)
    {
        return Ok(await _contentManager.UpdateContent(courseId,contentId,model));
    }

    [HttpDelete("{contentId}")]
    public async Task<IActionResult> DeleteContentById(Guid courseId,Guid contentId)
    {
        return Ok(await _contentManager.DeleteContent(courseId,contentId));
    }

}