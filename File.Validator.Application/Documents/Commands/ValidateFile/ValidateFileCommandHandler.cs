using File.Validator.Domain.Entities.DocumentEntity.Models;
using File.Validator.Domain.Entities.DocumentEntity.Repositories;
using File.Validator.Domain.Entities.DocumentLogEntity.Models;
using File.Validator.Domain.Entities.DocumentLogEntity.Repositories;
using File.Validator.Domain.Services.FileSaver;
using File.Validator.Domain.Services.VirusScanner;
using File.Validator.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.AccessControl;

namespace File.Validator.Application.Documents.Commands.ValidateFile;

public class ValidateFileCommandHandler : IRequestHandler<ValidateFileCommand, Result<ValidateFileCommandResponse>>
{
    private readonly IVirusScanner _virusScanner;
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentLogRepository _documentLogRepository;
    private readonly IFileSaver _fileSaver;

    public ValidateFileCommandHandler (IVirusScanner virusScanner, IDocumentRepository documentRepository, IDocumentLogRepository documentLogRepository, IFileSaver fileSaver)
    {
        _virusScanner = virusScanner;
        _documentRepository = documentRepository;
        _documentLogRepository = documentLogRepository;
        _fileSaver = fileSaver;
    }
    public async Task<Result<ValidateFileCommandResponse>> Handle(ValidateFileCommand request, CancellationToken cancellationToken)
    {
        if(request == null ||
           int.IsNegative(request.request.UserID) ||
           request.request.File == null ||
           request.request.File.Length == 0)
        {
            return Result<ValidateFileCommandResponse>.Failure(400, "IncompleteData", "All fields are required");
        }

        bool fileIsSafe;

        try
        {
            fileIsSafe = await _virusScanner.isSafe(request.request.File);
        }
        catch (Exception ex)
        {
            return Result<ValidateFileCommandResponse>.Failure(500, "VirusScanner API error", ex.Message);
        }

        DocumentLogRequestModel documentLogRequestModel;

        if(!fileIsSafe)
        {
            documentLogRequestModel = new DocumentLogRequestModel
            {
                UserId = request.request.UserID,
                FileName = request.request.File.FileName,
                Status = false,
                Description = "The uploaded file contained a virus or was corrupted",                
            };
            try
            {
                DocumentLogModel docLog = await _documentLogRepository.RegisterLog(documentLogRequestModel, cancellationToken);
            }
            catch (Exception ex)
            {
                return Result<ValidateFileCommandResponse>.Failure(500, "InternalServerError", ex.Message);
            }
            return Result<ValidateFileCommandResponse>.Failure(400, "InsecureFile", "The uploaded file contains a virus or is corrupted");
        }

        string path;
        try
        {
            path = await _fileSaver.SaveFileAsync(request.request.File);
        }
        catch (Exception ex)
        {
            return Result<ValidateFileCommandResponse>.Failure(500, "FileSaveError", ex.Message);
        }

        DocumentRequestModel documentRequestModel = new DocumentRequestModel
        {
            UserId = request.request.UserID,
            Path = path,
        };

        documentLogRequestModel = new DocumentLogRequestModel
        {
            UserId = request.request.UserID,
            FileName = request.request.File.FileName,
            Status = true,
            Description = "File saved successfully",
        };

        DocumentModel documentResponseModel;
        DocumentLogModel documentLogResponseModel;

        try
        {
            documentResponseModel = await _documentRepository.RegisterFile(documentRequestModel, cancellationToken);
            documentLogResponseModel = await _documentLogRepository.RegisterLog(documentLogRequestModel, cancellationToken);
        }
        catch (Exception ex)
        {
            return Result<ValidateFileCommandResponse>.Failure(500, "DataBaseError", ex.Message);
        }

        ValidateFileCommandResponse newDocument = new ValidateFileCommandResponse{
            Id = documentResponseModel.Id,
            UserId = documentResponseModel.UserId,
            Path = documentResponseModel.Path,
            UploadDate = documentResponseModel.UploadDate,
        };

        return Result<ValidateFileCommandResponse>.Success(newDocument);

    }
}
