using File.Validator.Domain.Services.VirusScanner;
using Microsoft.AspNetCore.Http;

namespace File.Validator.Tests.Infrastructure.Services;

public class VirusScannerMockService : IVirusScanner
{
    public async Task<bool> isSafe(IFormFile file)
    {
        await Task.Delay(2000);
        return false;
    }
}
