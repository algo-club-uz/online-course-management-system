using Course.Api.Context;
using Course.Api.Entities;

namespace Course.Api.Repositories;

public interface IDataRepository
{
    Task<List<Data>> GetDatas(Guid courseId, Guid contentId);

    Task AddData (Guid courseId,Data data);

    Task<Data> GetDataById (Guid courseId, Guid contentId, Guid dataId);

    Task UpdateData (Guid courseId,Data data);

    Task DeleteData (Guid courseId, Guid contentId, Guid dataId);

}

public class DataRepository : IDataRepository
{
    private readonly CourseDbContext _context;
    private readonly IContentRepository _contentRepository;

    public DataRepository(CourseDbContext context, IContentRepository contentRepository)
    {
        _context = context;
        _contentRepository = contentRepository;
    }

    public async Task<List<Data>> GetDatas(Guid courseId, Guid contentId)
    {
        var content = await _contentRepository.GetContentById(courseId, contentId);
        return content.Data.ToList();
    }

    public async Task AddData(Guid courseId, Data data)
    {
        var content = await _contentRepository.GetContentById(courseId, data.ContentId);
        _context.Data.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task<Data> GetDataById(Guid courseId, Guid contentId, Guid dataId)
    {
        var content = await _contentRepository.GetContentById(courseId, contentId);
        var data = content.Data.FirstOrDefault(d => d.DataId == dataId);
        if (data != null) return data;

        throw new System.Exception("Data Not Found");
    }

    public async Task UpdateData(Guid courseId, Data data)
    {
        var content = await _contentRepository.GetContentById(courseId, data.ContentId);
        _context.Data.Update(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteData(Guid courseId, Guid contentId, Guid dataId)
    {
        var data = await GetDataById(courseId, contentId, dataId);
        _context.Data.Remove(data);
        await _context.SaveChangesAsync();
    }
}

/*
    GET    courses/{course_id}/contents/{content_id}/datas
    POST   courses/{course_id}/contents/{content_id}/datas
    GET    courses/{course_id}/contents/{content_id}/datas/{data_id}
    PUT    courses/{course_id}/contents/{content_id}/datas/{data_id}
    DELETE courses/{course_id}/contents/{content_id}/datas/{data_id}

 */