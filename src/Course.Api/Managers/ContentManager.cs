using Course.Api.Entities;
using Course.Api.Models.ContentModels;
using Course.Api.Repositories;
using Course.Api.Services;

namespace Course.Api.Managers;

public class ContentManager
{
    private readonly IContentRepository _contentRepository;
    private readonly ParseService _parseService;

    public ContentManager(IContentRepository contentRepository, ParseService parseService)
    {
        _contentRepository = contentRepository;
        _parseService = parseService;
    }

    public async Task<List<ContentModel>?> GetContents(Guid courseId)
    {
        var contents = await _contentRepository.GetContents(courseId);
        return _parseService.ParseListModel(contents);
    }

    public async Task<ContentModel> AddContent(CreateContentModel model)
    {
        var content = new Content()
        {
            ContentName = model.ContentName,
            Description = model.Description,
            CourseId = model.CourseId,

        };

        await _contentRepository.AddContent(content);
        return _parseService.ParseModel(content);
    }

    public async Task<ContentModel> GetContentById(Guid courseId, Guid contentId)
    {
        var content = await _contentRepository.GetContentById(courseId, contentId);
        return _parseService.ParseModel(content);
    }

    public async Task<ContentModel> UpdateContent(Guid courseId, Guid contentId,CreateContentModel model)
    {
        var content = await _contentRepository.GetContentById(courseId, contentId);
        content.ContentName = model.ContentName;
        content.Description = model.Description;
        content.CourseId = courseId;
        await _contentRepository.UpdateContent(content);
        return _parseService.ParseModel(content);
    }

    public async Task<string> DeleteContent(Guid courseId, Guid contentId)
    {
        await _contentRepository.DeleteContent(courseId, contentId);
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