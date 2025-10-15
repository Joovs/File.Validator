using Microsoft.AspNetCore.Http;

namespace File.Validator.Domain.Services.FileSaver;

public interface IFileSaver
{
    Task<string> SaveFileAsync(IFormFile file);
}
