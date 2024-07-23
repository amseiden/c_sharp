//   DOMAIN IMPL
//   IPasswordHasher

using System.Security.Cryptography;
using System.Text;
using Common.Interfaces;

namespace DomainImpl
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly int _iterations = 10000;
        private readonly int _saltSize = 16;
        private readonly int _hashSize = 32;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize); // Generate a random salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(_hashSize);

            // Combine salt and hash for storage
            byte[] combined = new byte[salt.Length + hash.Length];
            Array.Copy(salt, 0, combined, 0, salt.Length);
            Array.Copy(hash, 0, combined, salt.Length, hash.Length);

            return Convert.ToBase64String(combined);
        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            byte[] combinedHash = Convert.FromBase64String(passwordHash);

            // Extract salt from the combined hash
            byte[] salt = new byte[_saltSize];
            Array.Copy(combinedHash, 0, salt, 0, salt.Length);

            // Extract actual hash from the combined hash
            byte[] hash = new byte[combinedHash.Length - salt.Length];
            Array.Copy(combinedHash, salt.Length, hash, 0, hash.Length);

            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, _iterations, HashAlgorithmName.SHA256);
            byte[] inputHashBytes = pbkdf2.GetBytes(_hashSize);

            return CryptographicOperations.FixedTimeEquals(inputHashBytes, hash);
        }
    }
}
