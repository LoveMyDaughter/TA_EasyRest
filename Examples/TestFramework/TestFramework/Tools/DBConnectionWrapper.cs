using System;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace TestFramework.Tools
{
    public class DBConnectionWrapper
    {

        private static readonly string _connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database= bitnami_opencart;";
       
        public static void ExecuteQuery(string queryString, string message = "", bool isTenantsDB = false)
        {

            MySqlConnection databaseConnection = new MySqlConnection(_connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(queryString, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetFirstnameById(string userId)
        {
            var queryString = $@"SELECT `firstname` FROM `oc_customer` WHERE `customer_id` = {userId}";

            ExecuteQuery(queryString, "SurveyTemplate was added");
        }
    }
}