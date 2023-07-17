namespace Course.Api.Entities;

public class Data
{ 
    public Guid DataId { get; set; }
    public required string DataName { get; set; }
    public string? Description { get; set; }
    public required string FileUrl {get;set; }
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;

    public Guid ContentId { get; set; }
    public virtual Content? Content { get; set; }
}