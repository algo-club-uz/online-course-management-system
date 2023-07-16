namespace Course.Api.Models.ContentModels;

public class CreateContentModel
{
    public required string ContentName { get; set; }
    public string? Description { get; set; }
    public Guid CourseId { get; set; }
}