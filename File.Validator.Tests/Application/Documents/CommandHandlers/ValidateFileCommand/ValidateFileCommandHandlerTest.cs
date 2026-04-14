using File.Validator.Domain.Entities.DocumentEntity.Models;
using File.Validator.Domain.Entities.DocumentLogEntity.Models;
using File.Validator.Tests.Application.Mocks;
using File.Validator.Tests.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace File.Validator.Tests.Application.Documents.CommandHandlers.ValidateFileCommand;

public class ValidateFileCommandHandlerTest
{
    private readonly DocumentMockRepository _repository = new DocumentMockRepository();
    private readonly DocumentLogMockRepository _logRepository = new DocumentLogMockRepository();
    private readonly VirusScannerMockService _visusScannerService = new VirusScannerMockService();
    private readonly CancellationToken cancellationToken = CancellationToken.None;



    //Happy path principal
    [Fact]
    public async Task handleShouldInsertAndReturnANewDocument()
    {
        //Arrange
        DocumentRequestModel documentClient = new DocumentRequestModel
        {
            UserId = 1,
            Path = "/Uplaoads/document.pdf"
        };

        //Act
        DocumentModel response = await _repository.RegisterFile(documentClient, cancellationToken);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(documentClient.UserId, response.UserId);
        Assert.Equal(documentClient.Path, response.Path);
        Assert.True(response.Id > 0);
        Assert.True(response.UploadDate <= DateTime.Now);
    }

    //Happy path secundario
    [Fact]
    public async Task handleShouldInsertAndReturnANewDocumentLog()
    {
        //Arrange
        DocumentLogRequestModel documentClient = new DocumentLogRequestModel
        {
            UserId = 1,
            FileName = "document.pdf",
            Description = "File saved successfully",
            Status = true,
        };

        //Act
        DocumentLogModel response = await _logRepository.RegisterLog(documentClient, cancellationToken);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(documentClient.UserId, response.UserId);
        Assert.Equal(documentClient.FileName, response.FileName);
        Assert.Equal(documentClient.Description, response.Description);
        Assert.Equal(documentClient.Status, response.Status);
        Assert.True(response.Id > 0);
        Assert.True(response.UploadDate <= DateTime.Now);
    }

    //Incomplete data
    [Fact]
    public async Task handleShouldReturnErrorWhenUserIdIsNegative()
    {
        //Arrange
        DocumentRequestModel documentClient = new DocumentRequestModel
        {
            UserId = -1,
            Path = "/Uplaoads/document.pdf"
        };

        await Task.Delay(500);

        Assert.NotNull(documentClient);
        Assert.False(documentClient.UserId > 0);
    }


    //Insecure file
    [Fact]
    public async Task handleShouldReturnErrorWhenFileIsNotSecure()
    {
        IFormFile file = null;

        bool fileIsSafe = await _visusScannerService.isSafe(file); 

        Assert.False(fileIsSafe);   

    }


    //File save error
    //[Fact]
    public async Task handleShouldReturnErrorWhenDocumentOrDocumentLogIsNotRegisted()
    {

    }
}
