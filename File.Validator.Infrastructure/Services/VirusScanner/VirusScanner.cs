using File.Validator.Domain.Services.VirusScanner;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using VirusTotalNet;

namespace File.Validator.Infrastructure.Services.VirusScanner;

public class VirusScanner : IVirusScanner
{
    private readonly VirusTotal _virusTotal;

    public VirusScanner(IConfiguration configuration)
    {
        var apiKey = configuration["VirusTotal:ApiKey"];

        _virusTotal = new VirusTotal(apiKey)
        {
            UseTLS = true
        };
    }

    public async Task<bool> isSafe(IFormFile file)
    {
        try
        {
            MemoryStream ms = new MemoryStream();
            
            await file.CopyToAsync(ms);
            ms.Position = 0;

            var scanResult = await _virusTotal.ScanFileAsync(ms, file.FileName);
            if (scanResult == null || string.IsNullOrEmpty(scanResult.Resource)) return false;

            var report = await _virusTotal.GetFileReportAsync(scanResult.Resource);
            if (report == null) return false;

            if (report.ResponseCode.ToString().Equals("Present", StringComparison.OrdinalIgnoreCase) || report.ResponseCode.ToString() == "1")
            {
                return report.Positives == 0;
            }

            return false;
           
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
        
    }
}
