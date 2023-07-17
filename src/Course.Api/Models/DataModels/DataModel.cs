using Course.Api.Entities;
using Course.Api.Models.ContentModels;

namespace Course.Api.Models.DataModels;

public class DataModel
{
    public Guid DataId { get; set; }
    public required string DataName { get; set; }
    public string? Description { get; set; }
    public required string FileUrl { get; set; }
    public DateTime CreateTime { get; set; }

    public Guid ContentId { get; set; }
    public  ContentModel? Content { get; set; }
}