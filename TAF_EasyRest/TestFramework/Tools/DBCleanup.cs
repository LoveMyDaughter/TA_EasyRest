namespace TestFramework.Tools
{
    public class DBCleanup
    {
        public static void DeleteUserByEmail(string userEmail)
        {
            string deleteUser = $"DELETE FROM users WHERE email = '{userEmail}'";
            DBConnectionWrapper.ExecuteQuery(deleteUser);
        }

        // This method means logout
        public static void DeleteLastTokenOfUserByEmail(string userEmail)
        {
            string deleteToken = $"delete from tokens where id = (SELECT tokens.id FROM tokens JOIN users ON tokens.user_id = users.id WHERE users.email = '{userEmail}' order by id desc limit 1)";
            DBConnectionWrapper.ExecuteQuery(deleteToken);
        }

        public static void DeleteRestaurantByName(string restaurantName)
        {
            string deleteRest = $"DELETE FROM restaurants WHERE name = '{restaurantName}'";
            DBConnectionWrapper.ExecuteQuery(deleteRest);
        }
    }
}
