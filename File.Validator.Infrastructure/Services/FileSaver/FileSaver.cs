using File.Validator.Domain.Services.FileSaver;
using Microsoft.AspNetCore.Http;

namespace File.Validator.Infrastructure.Services.FileSaver;

public class FileSaver : IFileSaver
{
    public async Task<string> SaveFileAsync(IFormFile file)
    {
        string path = Path.Combine("Uploads", file.FileName);

        Directory.CreateDirectory("Uploads");

        var stream = new FileStream(path, FileMode.Create);

        try
        {
            await file.CopyToAsync(stream);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return path;
    }
}
