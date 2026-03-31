using MySql.Data.MySqlClient;

namespace POS_system
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize database configuration
            AppConfig.InitializeDatabase();

            // Build connection string for MySQL
            var builder = new MySqlConnectionStringBuilder(Database.ConnectionString)
            {
                Server = "localhost",
                Database = "pos_db",          // your actual database name
                UserID = "pos_user",          // use the new MySQL user
                Password = "mitch@254.",      // replace with the password you set
                AllowPublicKeyRetrieval = true,
                SslMode = MySqlSslMode.Required
            };

            // Pass connection string to your database class
            Database.ConnectionString = builder.ConnectionString;

            // Test database connection before launching application
            if (!DatabaseInitializer.TestConnection())
            {
                Application.Exit();
                return;
            }

            Application.Run(new Login());
        }
    }
}
