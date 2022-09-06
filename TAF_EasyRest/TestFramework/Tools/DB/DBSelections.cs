namespace TestFramework.Tools.DB
{
    public class DBSelections
    {

        #region OrdersQueries

        public static int GetOrdersCountByStatus(string userEmail, string orderStatus = "Waiting for confirm")
        {
            string queryString = $"SELECT count(*) FROM orders WHERE status = '{orderStatus}' AND user_id = (SELECT id FROM users WHERE email = '{userEmail}') ";
            object ordersCount = DBConnectionWrapper.GetCellFromDB(queryString);
            return Convert.ToInt32(ordersCount);
        }

        public static int GetLastOrderIdByStatus(string orderStatus = "Waiting for confirm")
        {
            string queryString = $"SELECT id FROM orders WHERE status = '{orderStatus}' ORDER BY id DESC LIMIT 1";
            object orderId = DBConnectionWrapper.GetCellFromDB(queryString);
            return Convert.ToInt32(orderId);
        }
        #endregion

        public static bool CheckIfRestaurantExistsByName(string name, string user_id)
        {
            string query = $"SELECT count(*) FROM restaurants WHERE name = '{name}' AND owner_id = {user_id}";
            object restaurantCount = DBConnectionWrapper.GetCellFromDB(query);
            if (Convert.ToInt32(restaurantCount) > 0)
            {
                return true;
            }
            return false;
        }

        public static int GetUserId(string email)
        {
            string query = $"SELECT id FROM users WHERE email = '{email}'";
            object userId = DBConnectionWrapper.GetCellFromDB(query);
            return Convert.ToInt32(userId);
        }
    }
}
