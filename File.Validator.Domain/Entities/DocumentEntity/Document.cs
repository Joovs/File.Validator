using System.ComponentModel.DataAnnotations;

namespace File.Validator.Domain.Entities.DocumentEntity;

public class Document
{
    [Key]
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Path { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}
