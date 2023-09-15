using MediatorPatternTest.CoolClasses;
using MediatR;

namespace MediatorPatternTest.Commands.Encrypt;

public class EncryptHandler : IRequestHandler<EncryptRequest, string>
{
    private readonly ICryptographer _cryptographer;

    public EncryptHandler(ICryptographer cryptographer)
    {
        _cryptographer = cryptographer;
    }

    public Task<string> Handle(EncryptRequest request, CancellationToken cancellationToken)
    {
        var input = _cryptographer.Encrypt(request.Input, request.Shift);
        return Task.FromResult(input);
    }
}
