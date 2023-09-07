using Course.Api.Entities;
using Course.Api.Models.ContentModels;
using Course.Api.Repositories;
using Course.Api.Services;

namespace Course.Api.Managers;

public class ContentManager
{
    private readonly IUnitRepository _unitRepository;
    private readonly ParseService _parseService;

    public ContentManager(IUnitRepository unitRepository, ParseService parseService)
    {
        _unitRepository = unitRepository;
        _parseService = parseService;
    }

    public async Task<List<ContentModel>?> GetContents(Guid courseId)
    {
        var contents = await _unitRepository.Contents.GetContents(courseId);
        return _parseService.ParseListModel(contents);
    }

    public async Task<ContentModel> AddContent(Guid courseId,CreateContentModel model)
    {
        var content = new Content()
        {
            ContentName = model.ContentName,
            Description = model.Description,
            CourseId = courseId,

        };

        await _unitRepository.Contents.AddContent(content);
        return _parseService.ParseModel(content);
    }

    public async Task<ContentModel> GetContentById(Guid courseId, Guid contentId)
    {
        var content = await _unitRepository.Contents.GetContentById(courseId, contentId);
        return _parseService.ParseModel(content);
    }

    public async Task<ContentModel> UpdateContent(Guid courseId, Guid contentId,CreateContentModel model)
    {
        var content = await _unitRepository.Contents.GetContentById(courseId, contentId);
        content.ContentName = model.ContentName;
        content.Description = model.Description;
        await _unitRepository.Contents.UpdateContent(content);
        return _parseService.ParseModel(content);
    }

    public async Task<string> DeleteContent(Guid courseId, Guid contentId)
    {
        await _unitRepository.Contents.DeleteContent(courseId, contentId);
        return "Deleted";
    }

}

/*
     GET    courses/{course_id}/contents
     POST   courses/{course_id}/contents
     GET    courses/{course_id}/contents/{content_id}
     PUT    courses/{course_id}/contents/{content_id}
     DELETE courses/{course_id}/contents/{content_id}
 */