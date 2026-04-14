using File.Validator.Domain.Entities.DocumentEntity.Models;
using File.Validator.Domain.Entities.DocumentEntity.Repositories;

namespace File.Validator.Tests.Application.Mocks;

public class DocumentMockRepository : IDocumentRepository
{
    public async Task<DocumentModel> RegisterFile(DocumentRequestModel request, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
        DocumentModel newDocument = new DocumentModel
        {
            Id = 2,
            UserId = request.UserId,
            Path = request.Path,
            UploadDate = DateTime.Now
        };

        return newDocument;
    }
}
