namespace TestFramework.Tools

{
    public class DBCleanup
    {

        public void DeleteUser(string userEmail)
        {
            string deleteUser = $"DELETE FROM users WHERE email = '{userEmail}'";
            DBConnectionWrapper.ExecuteQuery(deleteUser);
            // NoUser Exception...
        }
    }
}
