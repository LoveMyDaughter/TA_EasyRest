using TestFramework.Tools.DB;

namespace TestFramework.Test
{
    public class BaseTest
    {
        protected string userEmail;
        protected string userPassword;
        protected string restaurantName;

        public void UserLogin(IWebDriver driver, string userEmail, string password)
        {
            SignInPage signInPage = new SignInPage(driver);

            signInPage.GoToUrl();
            signInPage.SendKeysToEmailField(userEmail)
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
            driver.WaitUntilUrlIsChanged();
        }

        public void UserLogout(string userEmail)
        {
            DBCleanup.DeleteLastTokenOfUserByEmail(userEmail);
        }

        public void AddRestaurant(string name)
        {
            DBAddition.AddRestaurantViaDB(name);
        }

        public void AddRestaurantWithArchivedStatus(string name)
        {
            DBAddition.AddRestaurantViaDB(name, "3807 Brook Street, Huston, TX 77030, USA", 1, 2);
        }

        public void DeleteRestaurant(string restaurantName)
        {
            DBCleanup.DeleteRestaurantByName(restaurantName);
        }

        public void CreateModerator(string email)
        {
            DBAddition.AddUserViaDB("0 Fake Moderator", email, 3, true);
        }
         
    }
}