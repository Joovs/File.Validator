namespace File.Validator.Application.Documents.Commands.ValidateFile;

public class ValidateFileCommandResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Path { get; set; } = string.Empty; 
    public DateTime UploadDate { get; set; }
}
