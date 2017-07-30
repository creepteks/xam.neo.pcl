using Liphsoft.Crypto.Argon2;

namespace neo.pcl
{
    public class CryptoService: ICryptoService
    {
        private PasswordHasher hasher = new PasswordHasher();

        public string HashPassword(string password, string salt)
        {
            return hasher.Hash(password, salt);
        }
        public bool ValidatePassword(string password, string hash)
        {
            return hasher.Verify(hash, password);
        }

        public bool ValidateAndUpdatePassword(string password, string expectedHash)
        {
            bool updated;
            string newHash = null;
            var res = hasher.VerifyAndUpdate(expectedHash, password, out updated, out newHash);
            return res;
        }
    }
}
