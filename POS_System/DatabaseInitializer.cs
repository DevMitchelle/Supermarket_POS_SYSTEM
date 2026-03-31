using MySql.Data.MySqlClient;

namespace POS_system
{
    /// <summary>
    /// Helper class for database initialization and connection validation.
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Tests the database connection and verifies that all required tables exist.
        /// </summary>
        /// <returns>True if connection is successful and tables exist; false otherwise.</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    return VerifyTablesExist(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}\n\nPlease ensure MySQL is running and the database is set up correctly.", 
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Verifies that all required tables exist in the database.
        /// </summary>
        private static bool VerifyTablesExist(MySqlConnection conn)
        {
            string[] requiredTables = { "Users", "Products", "Sales", "SaleItems", "Receipts", "Reports", "AuditLog" };

            foreach (var table in requiredTables)
            {
                string query = $"SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'pos_db' AND TABLE_NAME = '{table}'";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        MessageBox.Show($"Required table '{table}' not found in database.\n\nPlease run the Database_Setup.sql script first.", 
                            "Missing Database Tables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the count of users in the database.
        /// </summary>
        public static int GetUserCount()
        {
            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the count of products in the database.
        /// </summary>
        public static int GetProductCount()
        {
            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Products";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets database statistics for display purposes.
        /// </summary>
        public static Dictionary<string, int> GetDatabaseStats()
        {
            var stats = new Dictionary<string, int>();

            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();

                    stats["Users"] = GetTableCount(conn, "Users");
                    stats["Products"] = GetTableCount(conn, "Products");
                    stats["Sales"] = GetTableCount(conn, "Sales");
                    stats["Receipts"] = GetTableCount(conn, "Receipts");
                    stats["SaleItems"] = GetTableCount(conn, "SaleItems");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving database statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return stats;
        }

        /// <summary>
        /// Gets the count of records in a specific table.
        /// </summary>
        private static int GetTableCount(MySqlConnection conn, string tableName)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Logs an audit entry for database changes.
        /// </summary>
        public static void LogAudit(int userId, string action, string tableName, int recordId, string oldValue = null, string newValue = null)
        {
            try
            {
                using (var conn = new MySqlConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO AuditLog (UserId, Action, TableName, RecordId, OldValue, NewValue) " +
                                   "VALUES (@userId, @action, @tableName, @recordId, @oldValue, @newValue)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@action", action);
                        cmd.Parameters.AddWithValue("@tableName", tableName);
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        cmd.Parameters.AddWithValue("@oldValue", oldValue ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@newValue", newValue ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log to console or file instead of showing message box
                Console.WriteLine($"Audit logging failed: {ex.Message}");
            }
        }
    }
}
