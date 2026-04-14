using File.Validator.Domain.Entities.DocumentLogEntity.Models;
using File.Validator.Domain.Entities.DocumentLogEntity.Repositories;

namespace File.Validator.Tests.Application.Mocks;

public class DocumentLogMockRepository : IDocumentLogRepository
{
    public async Task<DocumentLogModel> RegisterLog(DocumentLogRequestModel request, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
        DocumentLogModel newDocument = new DocumentLogModel
        {
            Id = 2,
            UserId = request.UserId,
            FileName = request.FileName,
            Description = request.Description,
            Status = request.Status,
            UploadDate = DateTime.Now
        };

        return newDocument;
    }
}
