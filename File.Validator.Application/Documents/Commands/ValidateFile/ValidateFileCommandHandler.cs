using File.Validator.Domain.Shared;
using MediatR;

namespace File.Validator.Application.Documents.Commands.ValidateFile;

public class ValidateFileCommandHandler : IRequestHandler<ValidateFileCommand, Result<ValidateFileCommandResponse>>
{
    public Task<Result<ValidateFileCommandResponse>> Handle(ValidateFileCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
