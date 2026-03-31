using System.Security.Cryptography;
using System.Text;

namespace POS_system
{
    /// <summary>
    /// Utility class for password hash generation and verification.
    /// Use this to generate correct SHA-256 hashes for user passwords.
    /// </summary>
    public static class PasswordHashGenerator
    {
        /// <summary>
        /// Generates a SHA-256 hash for the given password.
        /// </summary>
        public static string GenerateHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets the default test credentials with their correct hashes.
        /// </summary>
        public static Dictionary<string, (string Password, string Hash, string Role)> GetDefaultCredentials()
        {
            return new Dictionary<string, (string, string, string)>
            {
                { "manager", ("manager123", GenerateHash("manager123"), "Manager") },
                { "cashier", ("cashier123", GenerateHash("cashier123"), "Cashier") },
                { "admin", ("admin123", GenerateHash("admin123"), "Admin") }
            };
        }

        /// <summary>
        /// Prints the correct hashes for default test users.
        /// </summary>
        public static void PrintDefaultHashes()
        {
            Console.WriteLine("==== Default User Credentials and Hashes ====\n");
            var credentials = GetDefaultCredentials();

            foreach (var kvp in credentials)
            {
                var (password, hash, role) = kvp.Value;
                Console.WriteLine($"Username: {kvp.Key}");
                Console.WriteLine($"Password: {password}");
                Console.WriteLine($"Role: {role}");
                Console.WriteLine($"Hash: {hash}");
                Console.WriteLine();
            }
        }
    }
}
