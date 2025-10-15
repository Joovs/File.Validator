using File.Validator.Domain.Entities.DocumentEntity.Models;

namespace File.Validator.Domain.Entities.DocumentEntity.Repositories;

public interface IDocumentRepository
{
    public Task<DocumentModel> RegisterFile(DocumentRequestModel request, CancellationToken cancellationToken);
}
