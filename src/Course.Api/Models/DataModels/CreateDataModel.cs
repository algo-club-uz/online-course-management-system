namespace Course.Api.Models.DataModels;

public class CreateDataModel
{
    public required string DataName { get; set; }
    public string? Description { get; set; }
    public required IFormFile DataFile { get; set; }

    public Guid ContentId { get; set; }
}