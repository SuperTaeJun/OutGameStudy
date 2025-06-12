using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class CryptoUtil : MonoBehaviour
{
    public static string Encryption(string text, string salt)
    {
        SHA256 sha256 = SHA256.Create();

        byte[] bytes = Encoding.UTF8.GetBytes(text + salt);
        byte[] hash = sha256.ComputeHash(bytes);

        string result = string.Empty;
        foreach (var b in hash)
        {
            result += b.ToString("X2");
        }

        return result;
    }

    public static bool Verify(string text, string hash, string salt = "")
    {
        Debug.Log(hash);
        Debug.Log(Encryption(text, salt));
        return Encryption(text, salt) == hash;
    }
}
