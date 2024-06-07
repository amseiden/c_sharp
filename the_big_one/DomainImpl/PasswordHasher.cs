//   DOMAIN IMPL
//   IPasswordHasher

using System.Security.Cryptography;
using System.Text;
using DomainApi;

namespace DomainImpl;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                stringBuilder.Append(hashedBytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }

    public bool Verify(string passwordHash, string inputPassword)
    {
        string inputHash = Hash(inputPassword);
        return string.Equals(passwordHash, inputHash, StringComparison.OrdinalIgnoreCase);
    }

}
