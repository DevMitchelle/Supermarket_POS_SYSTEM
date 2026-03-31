using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace POS_system
{
    public static class Auth
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns role ("Manager", "Cashier") or empty string on failure.
        /// Reads either `passwordHash` or legacy `Password`. If stored value looks like a SHA-256 hex string it compares hashes;
        /// otherwise it compares plaintext (legacy, not recommended).
        /// </summary>
        public static string AuthenticateUser(string username, string password)
        {
            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();

                    // Read either a passwordHash column or legacy Password column.
                    string query = "SELECT COALESCE(passwordHash, Password) AS storedPassword, role FROM Users WHERE Username = @username LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return string.Empty;

                            string stored = reader["storedPassword"] != DBNull.Value ? reader["storedPassword"].ToString() : string.Empty;
                            string role = reader["role"] != DBNull.Value ? reader["role"].ToString() : string.Empty;

                            if (string.IsNullOrEmpty(stored))
                                return string.Empty;

                            // Detect SHA-256 hex (64 hex chars)
                            bool storedIsSha256 = Regex.IsMatch(stored, "^[a-fA-F0-9]{64}$");

                            if (storedIsSha256)
                            {
                                string providedHash = ComputeSha256Hash(password);
                                if (string.Equals(stored, providedHash, StringComparison.OrdinalIgnoreCase))
                                    return role;
                            }
                            else
                            {
                                // Legacy plaintext comparison (NOT recommended). Keep for compatibility until migration.
                                if (string.Equals(stored, password, StringComparison.Ordinal))
                                    return role;
                            }

                            return string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Authentication error: " + ex.Message, "Auth Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}