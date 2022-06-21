using Business.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Business.Other
{
    public class SHA256Hasher : IHasher
    {
        public string GetHash(string value)
        {
            var builder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                foreach (byte b in result)
                    builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
