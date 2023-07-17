using Course.Api.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/contents/{contentId}/[controller]")]
[ApiController]
public class DatasController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDatas(Guid courseId, Guid contentId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddData(Guid courseId, Guid contentId, CreateDataModel model)
    {
        return Ok();
    }

    [HttpGet("{dataId}")]
    public async Task<IActionResult> GetDataById(Guid courseId, Guid contentId,Guid dataId)
    {
        return Ok();
    }
    [HttpDelete("{dataId}")]
    public async Task<IActionResult> DeleteById(Guid courseId, Guid contentId,Guid dataId)
    {
        return Ok();
    } 
    [HttpPut("{dataId}")]
    public async Task<IActionResult> UpdateById(Guid courseId, Guid contentId,Guid dataId)
    {
        return Ok();
    }
}