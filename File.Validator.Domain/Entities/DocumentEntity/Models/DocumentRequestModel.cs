namespace File.Validator.Domain.Entities.DocumentEntity.Models;

public class DocumentRequestModel
{
    public int UserId { get; set; }
    public string Path { get; set; } = string.Empty;
}
