using GoTask.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace GoTask.Infra.Security.Cryptography
{
    internal class BCrypt : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            return BC.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
    }
}
