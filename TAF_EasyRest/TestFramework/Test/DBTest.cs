using TestFramework.Tools;


namespace TestFramework.Test
{
    internal class DBTest
    {
        [Test]
        public void Show_Table_Users()
        {
            DBConnectionWrapper.Show_Users();
        }        
        
        [Test]
        public void Show_Table_User_Roles()
        {
            DBConnectionWrapper.Show_User_Roles();
        }

    }
}
