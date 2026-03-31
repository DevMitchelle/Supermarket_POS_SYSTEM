using System.Data;
using MySql.Data.MySqlClient;

namespace POS_system
{
    public static class Database
    {
        // Adjust this connection string to your environment (store securely in production).
        public static string ConnectionString { get; set; } =
            "server=localhost;user id=root;password=mitch@254.;database=pos_db;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static DataTable GetProducts()
        {
            var dt = new DataTable();

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Id, Name, Price, Stock, CreatedAt FROM Products ORDER BY Name";
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {
                // Avoid throwing from design-time; inspect logs in runtime.
            }

            return dt;
        }

        public static Product? GetProductByNameOrCode(string codeOrName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql;
                    int id;
                    if (int.TryParse(codeOrName, out id))
                    {
                        sql = "SELECT Id, Name, Price, Stock, CreatedAt FROM Products WHERE Id = @id LIMIT 1";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new Product
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Name = reader["Name"].ToString() ?? string.Empty,
                                        Price = Convert.ToDecimal(reader["Price"]),
                                        Stock = Convert.ToInt32(reader["Stock"]),
                                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                    };
                                }
                            }
                        }
                    }
                    else
                    {
                        sql = "SELECT Id, Name, Price, Stock, CreatedAt FROM Products WHERE Name = @name LIMIT 1";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", codeOrName);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new Product
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Name = reader["Name"].ToString() ?? string.Empty,
                                        Price = Convert.ToDecimal(reader["Price"]),
                                        Stock = Convert.ToInt32(reader["Stock"]),
                                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // swallow here; return null when not found or on error
            }

            return null;
        }

        public static bool AddProduct(string name, decimal price, int stock, out string message)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Products (Name, Price, Stock) VALUES (@name, @price, @stock)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.ExecuteNonQuery();
                    }
                }

                message = "Product added.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool UpdateProduct(int id, string name, decimal price, int stock, out string message)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Products SET Name=@name, Price=@price, Stock=@stock WHERE Id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            message = "Product not found.";
                            return false;
                        }
                    }
                }

                message = "Product updated.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteProduct(int id, out string message)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Products WHERE Id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            message = "Product not found.";
                            return false;
                        }
                    }
                }

                message = "Product deleted.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Saves a sale and its items, updates product stock, and returns the inserted Sale Id in 'message' on success.
        /// </summary>
        public static bool SaveSale(List<SaleItem> saleItems, decimal total, string cashierName, out string message)
        {
            message = string.Empty;
            if (saleItems == null || saleItems.Count == 0)
            {
                message = "No sale items.";
                return false;
            }

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert into Sales
                        string sqlSale = "INSERT INTO Sales (SaleDate, TotalAmount) VALUES (NOW(), @total)";
                        long saleId;
                        using (var cmdSale = new MySqlCommand(sqlSale, conn, tran))
                        {
                            cmdSale.Parameters.AddWithValue("@total", total);
                            cmdSale.ExecuteNonQuery();
                            saleId = cmdSale.LastInsertedId;
                            if (saleId == 0)
                            {
                                // fallback to LAST_INSERT_ID()
                                using (var cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tran))
                                {
                                    saleId = Convert.ToInt64(cmd2.ExecuteScalar());
                                }
                            }
                        }

                        // Insert sale items and update stock
                        string sqlItem = "INSERT INTO SaleItems (SaleId, ProductName, Quantity, Price, Subtotal) VALUES (@saleId, @name, @qty, @price, @subtotal)";
                        string sqlUpdateStock = "UPDATE Products SET Stock = Stock - @qty WHERE Name = @name";

                        foreach (var item in saleItems)
                        {
                            using (var cmdItem = new MySqlCommand(sqlItem, conn, tran))
                            {
                                cmdItem.Parameters.AddWithValue("@saleId", saleId);
                                cmdItem.Parameters.AddWithValue("@name", item.ProductName);
                                cmdItem.Parameters.AddWithValue("@qty", item.Quantity);
                                cmdItem.Parameters.AddWithValue("@price", item.Price);
                                cmdItem.Parameters.AddWithValue("@subtotal", item.Subtotal);
                                cmdItem.ExecuteNonQuery();
                            }

                            using (var cmdUpd = new MySqlCommand(sqlUpdateStock, conn, tran))
                            {
                                cmdUpd.Parameters.AddWithValue("@qty", item.Quantity);
                                cmdUpd.Parameters.AddWithValue("@name", item.ProductName);
                                cmdUpd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        message = saleId.ToString();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        message = ex.Message;
                        return false;
                    }
                } // transaction
            } // connection
        }

        // --------------- User management helpers -----------------

        public static DataTable GetUsers()
        {
            var dt = new DataTable();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Id, Username, Role, CreatedAt FROM Users ORDER BY Username";
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {
                // swallow; return empty table on error
            }
            return dt;
        }

        public static bool AddUser(string username, string password, string role, out string message)
        {
            message = string.Empty;
            try
            {
                string hashed = Auth.ComputeSha256Hash(password);
                using (var conn = GetConnection())
                {
                    conn.Open();

                    // Try to insert into passwordHash if column exists; otherwise fallback to legacy Password column.
                    try
                    {
                        string sql = "INSERT INTO Users (Username, passwordHash, Role) VALUES (@username, @pwhash, @role)";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@pwhash", hashed);
                            cmd.Parameters.AddWithValue("@role", role);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (MySqlException)
                    {
                        // Fallback to legacy Password column
                        string sql2 = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                        using (var cmd2 = new MySqlCommand(sql2, conn))
                        {
                            cmd2.Parameters.AddWithValue("@username", username);
                            cmd2.Parameters.AddWithValue("@password", password);
                            cmd2.Parameters.AddWithValue("@role", role);
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
                message = "User added.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool UpdateUser(int id, string username, string password, string role, out string message)
        {
            message = string.Empty;
            try
            {
                string hashed = Auth.ComputeSha256Hash(password);
                using (var conn = GetConnection())
                {
                    conn.Open();
                    try
                    {
                        string sql = "UPDATE Users SET Username=@username, passwordHash=@pwhash, Role=@role WHERE Id=@id";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@pwhash", hashed);
                            cmd.Parameters.AddWithValue("@role", role);
                            cmd.Parameters.AddWithValue("@id", id);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                message = "User not found.";
                                return false;
                            }
                        }
                    }
                    catch (MySqlException)
                    {
                        // fallback to legacy Password column update
                        string sql2 = "UPDATE Users SET Username=@username, Password=@password, Role=@role WHERE Id=@id";
                        using (var cmd2 = new MySqlCommand(sql2, conn))
                        {
                            cmd2.Parameters.AddWithValue("@username", username);
                            cmd2.Parameters.AddWithValue("@password", password);
                            cmd2.Parameters.AddWithValue("@role", role);
                            cmd2.Parameters.AddWithValue("@id", id);
                            int rows = cmd2.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                message = "User not found.";
                                return false;
                            }
                        }
                    }
                }

                message = "User updated.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteUser(int id, out string message)
        {
            message = string.Empty;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Users WHERE Id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            message = "User not found.";
                            return false;
                        }
                    }
                }
                message = "User deleted.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Change password: verifies old password (supports legacy plaintext or SHA-256 hash) then updates to SHA-256 in passwordHash if possible,
        /// falling back to updating Password column if necessary.
        /// </summary>
        public static bool ChangePassword(string username, string oldPassword, string newPassword, out string message)
        {
            message = string.Empty;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COALESCE(passwordHash, Password) AS storedPassword FROM Users WHERE Username = @username LIMIT 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var storedObj = cmd.ExecuteScalar();
                        if (storedObj == null)
                        {
                            message = "User not found.";
                            return false;
                        }

                        string stored = storedObj.ToString() ?? string.Empty;
                        bool storedIsSha256 = System.Text.RegularExpressions.Regex.IsMatch(stored, "^[a-fA-F0-9]{64}$");

                        if (storedIsSha256)
                        {
                            string oldHash = Auth.ComputeSha256Hash(oldPassword);
                            if (!string.Equals(oldHash, stored, StringComparison.OrdinalIgnoreCase))
                            {
                                message = "Old password does not match.";
                                return false;
                            }
                        }
                        else
                        {
                            if (!string.Equals(oldPassword, stored, StringComparison.Ordinal))
                            {
                                message = "Old password does not match.";
                                return false;
                            }
                        }

                        string newHash = Auth.ComputeSha256Hash(newPassword);

                        // Try updating passwordHash
                        try
                        {
                            string upd = "UPDATE Users SET passwordHash = @newHash WHERE Username = @username";
                            using (var ucmd = new MySqlCommand(upd, conn))
                            {
                                ucmd.Parameters.AddWithValue("@newHash", newHash);
                                ucmd.Parameters.AddWithValue("@username", username);
                                int rows = ucmd.ExecuteNonQuery();
                                if (rows > 0)
                                {
                                    message = "Password changed.";
                                    return true;
                                }
                            }
                        }
                        catch (MySqlException)
                        {
                            // fallback below
                        }

                        // Fallback: update legacy Password column with plaintext new password (not ideal)
                        string upd2 = "UPDATE Users SET Password = @newPassword WHERE Username = @username";
                        using (var ucmd2 = new MySqlCommand(upd2, conn))
                        {
                            ucmd2.Parameters.AddWithValue("@newPassword", newPassword);
                            ucmd2.Parameters.AddWithValue("@username", username);
                            int rows2 = ucmd2.ExecuteNonQuery();
                            if (rows2 > 0)
                            {
                                message = "Password changed (legacy column).";
                                return true;
                            }
                        }

                        message = "Failed to change password.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}