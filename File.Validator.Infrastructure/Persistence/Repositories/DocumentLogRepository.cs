using File.Validator.Domain.Entities.DocumentLogEntity;
using File.Validator.Domain.Entities.DocumentLogEntity.Models;
using File.Validator.Domain.Entities.DocumentLogEntity.Repositories;
using File.Validator.Infrastructure.Persistence.Context;

namespace File.Validator.Infrastructure.Persistence.Repositories;

public class DocumentLogRepository(ApplicationDbContext context) : IDocumentLogRepository
{
    public async Task<DocumentLogModel> RegisterLog(DocumentLogRequestModel request, CancellationToken cancellationToken)
    {
        DocumentLog newDocumentLog = new DocumentLog
        {
            UserId = request.UserId,
            FileName = request.FileName,
            Status = request.Status,
            Description = request.Description,
            UploadDate = DateTime.Now,
        };

        try
        {
            await context.DocumentsLog.AddAsync(newDocumentLog, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            throw new Exception();
        }

        DocumentLogModel documentModel = new DocumentLogModel
        {
            Id = newDocumentLog.Id,
            UserId = newDocumentLog.UserId,
            FileName = newDocumentLog.FileName,
            Status = newDocumentLog.Status,
            Description = newDocumentLog.Description,
            UploadDate = newDocumentLog.UploadDate,
        };

        return documentModel;
    }
}
