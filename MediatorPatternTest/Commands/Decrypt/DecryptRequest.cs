using MediatR;

namespace MediatorPatternTest.Commands.Decrypt;

public class DecryptRequest : IRequest<string>
{
    public string Encryption { get; set; } = default!;
    public int Shift { get; set; }
}
