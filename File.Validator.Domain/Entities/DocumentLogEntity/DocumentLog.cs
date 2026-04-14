using System.ComponentModel.DataAnnotations;

namespace File.Validator.Domain.Entities.DocumentLogEntity;

public class DocumentLog
{
    [Key]
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Description { get; set; }  = string.Empty;
    public DateTime UploadDate { get; set; }
}
