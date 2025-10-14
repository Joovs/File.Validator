using File.Validator.Domain.Entities.DocumentEntity.Models.DocumentLog;

namespace File.Validator.Domain.Entities.DocumentEntity.Repositories;

public interface IDocumnetLogRepository
{
    Task<DocumentLogModel> RegisterLog(DocumentLogRequestModel request, CancellationToken cancellationToken);
}
