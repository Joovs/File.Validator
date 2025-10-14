using File.Validator.Domain.Entities.DocumentEntity;
using File.Validator.Domain.Entities.DocumentEntity.Models;
using File.Validator.Domain.Entities.DocumentEntity.Repositories;
using File.Validator.Infrastructure.Persistence.Context;

namespace File.Validator.Infrastructure.Persistence.Repositories;

public class DocumentRepository(ApplicationDbContext context) : IDocumentRepository
{
    public async Task<DocumentModel> RegisterFile(DocumentRequestModel request, CancellationToken cancellationToken)
    {
        Document newDocument = new Document
        {
            UserId = request.UserId,
            Path = request.Path,
            UploadDate = DateTime.Now,
        };

        try
        {
            await context.Documents.AddAsync(newDocument, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            throw new Exception();
        }

        DocumentModel docuementModel = new DocumentModel
        {
            Id = newDocument.Id,
            UserId = newDocument.UserId,
            Path = newDocument.Path,
            UploadDate = newDocument.UploadDate,
        };

        return docuementModel;
    }
}
