using File.Validator.Domain.Entities.DocumentLogEntity.Models;

namespace File.Validator.Domain.Entities.DocumentLogEntity.Repositories;

public interface IDocumentLogRepository
{
    Task<DocumentLogModel> RegisterLog(DocumentLogRequestModel request, CancellationToken cancellationToken);
}
