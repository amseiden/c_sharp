using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert the byte array to a hexadecimal string
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
        // Hash the input password and compare it with the stored hash
        string inputHash = Hash(inputPassword);
        return string.Equals(passwordHash, inputHash, StringComparison.OrdinalIgnoreCase);
    }

}