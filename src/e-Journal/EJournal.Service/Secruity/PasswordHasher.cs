
namespace e_Journal.Api.Secruity
{
    public class PasswordHasher 
    {
        public (string passwordHash, string salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string strongpassword = salt + password;
            string hash = BCrypt.Net.BCrypt.HashPassword(strongpassword);
            return (passwordHash: hash,
                    salt: salt);
        }

        public bool Verify(string password, string salt, string hash)
        {
            string strongpassword = salt + password;
            var newhash = BCrypt.Net.BCrypt.Verify(strongpassword, hash);
            return newhash;
        }

        private string GenerateSalt()
        {
            string salt = Guid.NewGuid().ToString();
            return salt;
        }
    }
}
