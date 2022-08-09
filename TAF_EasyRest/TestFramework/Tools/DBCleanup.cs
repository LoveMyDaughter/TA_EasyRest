namespace TestFramework.Tools

{
    public class DBCleanup
    {

        public static void DeleteUserByEmail(string userEmail)
        {
            string deleteUser = $"DELETE FROM users WHERE email = '{userEmail}'";
            DBConnectionWrapper.ExecuteQuery(deleteUser);
            // NoUser Exception...
        }

        // If user logs out correctly - the token is removed automatically
        public static void DeleteTokenAfterLogin(string userEmail)
        {
            string deleteUser = $"DELETE FROM users WHERE email = '{userEmail}'";
            DBConnectionWrapper.ExecuteQuery(deleteUser);
            // NoUser Exception...
        }


    }
}
