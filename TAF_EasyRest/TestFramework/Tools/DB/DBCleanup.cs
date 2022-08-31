﻿namespace TestFramework.Tools.DB
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

        public static void ChangeOrderStatusByNumber(string status, string number)
        {
            string id = number.Remove(0, 1);
            string query = $"UPDATE orders SET status = '{status}' WHERE id={id};";
            DBConnectionWrapper.ExecuteQuery(query);
        }

        public static void ChangeOrderStatus(string orderId, string orderStatus = "Waiting for confirm")
        {
            string changeStatus = $"UPDATE orders SET status = '{orderStatus}' WHERE id = {orderId};";
            DBConnectionWrapper.ExecuteQuery(changeStatus);
        }

        public static void UnlinkAdministratorFromRestaurant(string administratorEmail)
        {
            string unlinkAdministrator = $"UPDATE restaurants SET administrator_id = NULL WHERE administrator_id = (SELECT id FROM users WHERE email = '{administratorEmail}')";
            DBConnectionWrapper.ExecuteQuery(unlinkAdministrator);
        }

        public static void ChangeUserRole(int role_id, string email)
        {
            string query = $"UPDATE users SET role_id = {role_id} WHERE email = '{email}'";
            DBConnectionWrapper.ExecuteQuery(query);
        }
    }
}