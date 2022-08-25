using TestFramework.Tools;
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

        public void DeleteRestaurant(string restaurantName)
        {
            DBCleanup.DeleteRestaurantByName(restaurantName);
        }

    }
}