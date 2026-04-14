using File.Validator.Application.Documents.Commands.ValidateFile;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace File.Validator.Presentation.Modules;

public static class DocumentModules
{
    private const string BASE_URL = "api/v1/document/";
    public static void AddUserModules(this IEndpointRouteBuilder app)
    {
        var customerGroup = app.MapGroup(BASE_URL);

        customerGroup.MapPost("", ValidateFile)
            .DisableAntiforgery();
    }

    private static async Task<IResult> ValidateFile(
        [FromForm] int userId,
        IFormFile file,
        ISender sender,
        CancellationToken cancellationToken)
    {
        ValidateFileCommandRequest request = new ValidateFileCommandRequest
        {
            UserID = userId,
            File = file,
        };
        ValidateFileCommand command = new ValidateFileCommand(request);
        var result = await sender.Send(command, cancellationToken);

        if (!result.IsSuccess)
        {
            return Results.Problem(
                detail: result.Error?.ErrorMessage ?? result.Message,
                statusCode: result.StatusCode ?? 400,
                title: result.Error?.ErrorCode
            );
        }

        return Results.Created($"{BASE_URL}{result.Value.Id}", result.Value);
    }
}
