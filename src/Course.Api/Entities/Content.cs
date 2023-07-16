namespace Course.Api.Entities;

public class Content
{
    public Guid ContentId { get; set; }
    public required string ContentName { get; set; }
    public string? Description { get; set; }

    public Guid CourseId { get; set; }
    public virtual Course? Course { get; set; }

    public virtual List<Data>? Data { get; set; }
}