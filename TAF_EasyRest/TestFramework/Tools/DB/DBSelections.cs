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
    }
}
