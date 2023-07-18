using Course.Api.Entities;
using Course.Api.Models;
using Course.Api.Models.ContentModels;
using Course.Api.Models.CourseModels;
using Course.Api.Models.DataModels;

namespace Course.Api.Services;

public class ParseService
{
    public CourseModel ParseModel(Entities.Course model)
    {
        return new CourseModel()
        {
            CourseId = model.CourseId,
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
            CourseStatus = model.CourseStatus,
            CreateTime = model.CreateTime,
            Contents = ParseListModel(model.Contents),
            UserCourses = ParseListModel(model.UserCourses)

        };

    }

    public List<CourseModel>? ParseListModel(List<Entities.Course>? models)
    {
        if (models == null) return null;
        var parseModels = new List<CourseModel>();
        foreach (var model in models)
        {
            parseModels.Add(ParseModel(model));
        }
        return parseModels;
    }

    public ContentModel ParseModel(Content model)
    {
        return new ContentModel()
        {
            ContentId = model.ContentId,
            ContentName = model.ContentName,
            Description = model.Description,
            CreateTime = model.CreateTime,
            CourseId = model.CourseId,
            Data = ParseListModel(model.Data!)
        };
    }

    public List<ContentModel>? ParseListModel(List<Content>? models)
    {
        if (models == null) return null;
        var parseModels = new List<ContentModel>();
        foreach (var model in models)
        {
            parseModels.Add(ParseModel(model));
        }
        return parseModels;
    }

    public DataModel ParseModel(Data model)
    {
        return new DataModel()
        {
            DataId = model.DataId,
            DataName = model.DataName,
            Description = model.Description,
            FileUrl =model.FileUrl,
            CreateTime = model.CreateTime,
            ContentId = model.ContentId
        };
    }

    public List<DataModel>? ParseListModel(List<Data>? models)
    {
        if (models == null) return null;
        var parseModels = new List<DataModel>();
        foreach (var model in models)
        {
            parseModels.Add(ParseModel(model));
        }

        return parseModels;
    }

    public UserCourseModel ParseModel(UserCourse model)
    {
        return new UserCourseModel()
        {
            Id = model.Id,
            UserId = model.UserId,
            CourseId = model.CourseId,
            EUserCourseStatus = model.EUserCourseStatus
        };
    }

    public List<UserCourseModel>? ParseListModel(List<UserCourse>? models)
    {
        if (models == null) return null;
        var parseModels = new List<UserCourseModel>();
        foreach (var model in models)
        {
            parseModels.Add(ParseModel(model));
        }
        return parseModels;
    }
}