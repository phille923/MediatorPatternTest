using System.Text;

namespace MediatorPatternTest.CoolClasses;

public class Cryptographer : ICryptographer
{
    public string Encrypt(string plaintext, int shift)
    {
        StringBuilder encrypted = new StringBuilder();

        foreach (char c in plaintext)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                encrypted.Append((char)((c + shift - offset) % 26 + offset));
            }
            else
                encrypted.Append(c);
        }

        return encrypted.ToString();
    }

    public string Decrypt(string encryptedText, int shift)
    {
        return Encrypt(encryptedText, 26 - shift);
    }
}
