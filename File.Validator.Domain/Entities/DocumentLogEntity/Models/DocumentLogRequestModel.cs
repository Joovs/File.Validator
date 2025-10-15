namespace File.Validator.Domain.Entities.DocumentLogEntity.Models;

public class DocumentLogRequestModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Description { get; set; } = string.Empty;
}
