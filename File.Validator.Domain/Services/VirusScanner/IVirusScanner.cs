using Microsoft.AspNetCore.Http;

namespace File.Validator.Domain.Services.VirusScanner;

public interface IVirusScanner
{
    Task<bool> isSafe(IFormFile file);
}
