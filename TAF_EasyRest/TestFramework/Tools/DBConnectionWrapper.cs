using Npgsql;

namespace TestFramework.Tools
{
    internal class DBConnectionWrapper
    {
        private static readonly string pg_connectionString = "Host=localhost;Username=admin;Password=12345678;Database=easyrest";
        
        public static void ExecuteQuery(string queryString)
        {
            using (var connection = new NpgsqlConnection(pg_connectionString))
            {
                var command = new NpgsqlCommand(queryString, connection);
                command.Connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
