namespace File.Validator.Domain.Entities.DocumentEntity.Models;

public class DocumentModel
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Path { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}
