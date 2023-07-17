using Course.Api.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/contents/{contentId}/[controller]")]
[ApiController]
public class DatasController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDatas()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddData(CreateDataModel model)
    {
        return Ok();
    }

    [HttpGet("{dataId}")]
    public async Task<IActionResult> GetDataById(Guid dataId)
    {
        return Ok();
    }
    [HttpDelete("{dataId}")]
    public async Task<IActionResult> DeleteById(Guid dataId)
    {
        return Ok();
    } 
    [HttpPut("{dataId}")]
    public async Task<IActionResult> UpdateById(Guid dataId)
    {
        return Ok();
    }
}