using Npgsql;

namespace TestFramework.Tools.DB
{
    internal class DBConnectionWrapper
    {
        private static readonly string pg_connectionString = GetUrls.getUrl("DBCredentials").Url;

        public static void ExecuteQuery(string queryString)
        {
            using (var connection = new NpgsqlConnection(pg_connectionString))
            {
                var command = new NpgsqlCommand(queryString, connection);
                command.Connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
            }
        }

        public static object GetCellFromDB(string queryString)
        {
            using (var connection = new NpgsqlConnection(pg_connectionString))
            {
                var command = new NpgsqlCommand(queryString, connection);
                command.Connection.Open();
                object responseCell = command.ExecuteScalar();  //Returns the first column of the first row in the result set returned by the query
                return responseCell;
            }
        }
        public static void ExecuteNonQuery(string queryString)
        {
            using (var connection = new NpgsqlConnection(pg_connectionString))
            {
                var command = new NpgsqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}