using Course.Api.Managers;
using Course.Api.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;

[Route("api/courses/{courseId}/contents/{contentId}/[controller]")]
[ApiController]
public class DatasController : ControllerBase
{
    private readonly DataManager _dataManager;

    public DatasController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetDatas(Guid courseId, Guid contentId)
    {
        var data = await _dataManager.GetDatas(courseId, contentId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddData(Guid courseId, Guid contentId, CreateDataModel model)
    {
        return Ok(await _dataManager.AddData(courseId,contentId,model));
    }

    [HttpGet("{dataId}")]
    public async Task<IActionResult> GetDataById(Guid courseId, Guid contentId,Guid dataId)
    {
        return Ok(await _dataManager.GetDataById(courseId,contentId,dataId));
    }


    [HttpPut("{dataId}")]
    public async Task<IActionResult> UpdateById(Guid courseId, Guid contentId, Guid dataId,CreateDataModel model)
    {
        return Ok(await _dataManager.UpdateData(courseId, contentId, dataId,model));
    }

    [HttpDelete("{dataId}")]
    public async Task<IActionResult> DeleteById(Guid courseId, Guid contentId,Guid dataId)
    {
        return Ok(await _dataManager.DeleteData(courseId, contentId, dataId));
    } 

}