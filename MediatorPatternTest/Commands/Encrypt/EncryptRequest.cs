using MediatR;

namespace MediatorPatternTest.Commands.Encrypt;

public class EncryptRequest : IRequest<string>
{
    public string Input { get; set; } = default!;
    public int Shift { get; set; }
}
