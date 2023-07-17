using Course.Api.Entities;
using Course.Api.Models.CourseModels;
using Course.Api.Models.DataModels;

namespace Course.Api.Models.ContentModels;

public class ContentModel
{
    public Guid ContentId { get; set; }
    public required string ContentName { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; set; } 

    public Guid CourseId { get; set; }
    public  CourseModel? Course { get; set; }

    public  List<DataModel>? Data { get; set; }
}