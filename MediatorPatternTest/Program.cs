using MediatorPatternTest.Commands.Encrypt;
using MediatorPatternTest.Commands.Decrypt;
using MediatorPatternTest.CoolClasses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<ICryptographer, Cryptographer>();
services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(EncryptRequest).Assembly));

using var serviceProvider = services.BuildServiceProvider();
var mediator = serviceProvider.GetService<IMediator>()!;

var shift = 4;
Console.WriteLine("Enter a string to encrypt (English alphabet): ");
var input = Console.ReadLine()!;

var encryptionRequest = new EncryptRequest { Input = input, Shift = shift };
var encryptedText = await mediator.Send(encryptionRequest);

Console.WriteLine($"Encrypted string: {encryptedText}");

Console.WriteLine("Do you want to decrypt the string? (yes/no)");
if (Console.ReadLine()!.ToLower() == "yes")
{
    var decryptionRequest = new DecryptRequest { Encryption = encryptedText, Shift = shift };
    var decryptedText = await mediator.Send(decryptionRequest);
    Console.WriteLine($"Decrypted string: {decryptedText}");
}