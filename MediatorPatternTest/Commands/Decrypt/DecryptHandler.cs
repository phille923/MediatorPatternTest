using MediatorPatternTest.CoolClasses;
using MediatR;

namespace MediatorPatternTest.Commands.Decrypt;

public class DecryptHandler : IRequestHandler<DecryptRequest, string>
{
    private readonly ICryptographer _cryptographer;

    public DecryptHandler(ICryptographer cryptographer)
    {
        _cryptographer = cryptographer;
    }

    public Task<string> Handle(DecryptRequest request, CancellationToken cancellationToken)
    {
        var encryptedInput = _cryptographer.Decrypt(request.Encryption, request.Shift);
        return Task.FromResult(encryptedInput);
    }
}
