using File.Validator.Domain.Shared;
using MediatR;

namespace File.Validator.Application.Documents.Commands.ValidateFile;

public sealed record ValidateFileCommand (ValidateFileCommandRequest request) : IRequest<Result<ValidateFileCommandResponse>>
{
}
