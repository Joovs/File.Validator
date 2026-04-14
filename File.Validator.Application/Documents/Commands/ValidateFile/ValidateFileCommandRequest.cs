using Microsoft.AspNetCore.Http;

namespace File.Validator.Application.Documents.Commands.ValidateFile;

public class ValidateFileCommandRequest
{
    public int UserID { get; set; }
    public required IFormFile File { get; set; }
}
