using Npgsql;

namespace TestFramework.Tools
{
    internal class DBConnectionWrapper
    {

        private static readonly string pg_connectionString = "Host=localhost;Username=admin;Password=12345678;Database=easyrest";

        static void ShowHeaders(NpgsqlDataReader reader)
        {
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                        .Select(reader.GetName)
                        .ToArray();
            foreach (var column in columnNames) { Console.Write($"{column}\t"); }
            Console.WriteLine();
        }

        static void ShowRows(NpgsqlDataReader reader)
        {
            while (reader.Read())
            {
                var row = Enumerable.Range(0, reader.FieldCount)
                    .Select(reader.GetValue).ToArray();
                foreach (var column in row) { Console.Write($"{column}\t"); }
                Console.WriteLine();
            }
        }

        public static void ExecuteQuery(string queryString)
        {
            using (var connection = new NpgsqlConnection(pg_connectionString))
            {
                var command = new NpgsqlCommand(queryString, connection);
                command.Connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                // If the answer of execute query in not empty - show column names & all rows below 
                if (reader.HasRows)
                {
                    ShowHeaders(reader);
                    ShowRows(reader);
                }
                else { Console.WriteLine("No rows in the table."); }
            }
        }
    }
}
