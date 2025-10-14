using Microsoft.AspNetCore.Http;

namespace File.Validator.Application.Documents.Commands.ValidateFile;

public class ValidateFileCommandRequest
{
    public int UserID { get; set; }
    public IFormFile? File { get; set; }
}
