namespace MediatorPatternTest.CoolClasses;

public interface ICryptographer
{
    string Encrypt(string plainText, int shift);
    string Decrypt(string encryptedText, int shift);
}
