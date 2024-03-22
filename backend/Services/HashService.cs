using System.Security.Cryptography;
using System.Text;

namespace backend.Services;

public class HashService
{
    public string Sha256(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = SHA256.HashData(bytes);
        string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

        return hashString;
    }
}