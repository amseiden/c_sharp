//   DOMAIN IMPL
//   IPasswordHasher

using System.Security.Cryptography;
using System.Text;
using Common.Interfaces;

namespace DomainImpl
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly int _iterations;
        private readonly int _saltSize;
        private readonly int _hashSize;

        public PasswordHasher(int iterations = 10000, int saltSize = 16, int hashSize = 32)
        {
            _iterations = iterations;
            _saltSize = saltSize;
            _hashSize = hashSize;
        }

        public string Hash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize); // Generate a random salt

            var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, _iterations, HashAlgorithmName.SHA256);
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

            byte[] inputHashBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(inputPassword), salt, _iterations, HashAlgorithmName.SHA256).GetBytes(_hashSize);

            return SecureEquals(inputHashBytes, hash); // Use secure comparison for security
        }

        private static bool SecureEquals(byte[] a, byte[] b)
        {
            int length = a.Length;
            bool areEqual = true;
            for (int i = 0; i < length; i++)
            {
                areEqual &= (a[i] == b[i]);
            }
            return areEqual;
        }
    }
}
