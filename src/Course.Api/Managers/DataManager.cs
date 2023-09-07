using Course.Api.Entities;
using Course.Api.Models.DataModels;
using Course.Api.Repositories;
using Course.Api.Services;

namespace Course.Api.Managers;

public class DataManager
{
    private readonly IUnitRepository _unitRepository;
    private readonly ParseService _parseService;

    public DataManager(IUnitRepository unitRepository, ParseService parseService)
    {
        _unitRepository = unitRepository;
        _parseService = parseService;
    }

    public async Task<List<DataModel>?> GetDatas(Guid courseId, Guid contentId)
    {
        var datas = await _unitRepository.Data.GetDatas(courseId, contentId);
        return _parseService.ParseListModel(datas);
    }

    public async Task<DataModel> AddData(Guid courseId,Guid contentId, CreateDataModel model)
    {
        var data = new Data()
        {
            DataName = model.DataName,
            Description = model.Description,
            FileUrl = await FileService.SaveFile(model.DataFile),
            ContentId = contentId
        };
        await _unitRepository.Data.AddData(courseId,data);
        return _parseService.ParseModel(data);
    }

    public async Task<DataModel> GetDataById(Guid courseId, Guid contentId, Guid dataId)
    {
        var data = await _unitRepository.Data.GetDataById(courseId,contentId,dataId);
        return _parseService.ParseModel(data);
    }

    public async Task<DataModel> UpdateData(Guid courseId, Guid contentId, Guid dataId,CreateDataModel model)
    {
        var data = await _unitRepository.Data.GetDataById(courseId, contentId, dataId);

        data.DataName = model.DataName;
        data.Description = model.Description;
        data.FileUrl = await FileService.SaveFile(model.DataFile);

        await _unitRepository.Data.UpdateData(courseId, data);

        return _parseService.ParseModel(data);
    }

    public async Task<string> DeleteData(Guid courseId, Guid contentId, Guid dataId)
    {
        await _unitRepository.Data.DeleteData(courseId, contentId, dataId);
        return "Deleted";
    }

}

/*
    GET    courses/{course_id}/contents/{content_id}/datas
    POST   courses/{course_id}/contents/{content_id}/datas
    GET    courses/{course_id}/contents/{content_id}/datas/{data_id}
    PUT    courses/{course_id}/contents/{content_id}/datas/{data_id}
    DELETE courses/{course_id}/contents/{content_id}/datas/{data_id}
 */