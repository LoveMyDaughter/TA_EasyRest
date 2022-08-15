using TestFramework.Tools;
namespace TestFramework.Test
{
    public class BaseTest
    {
        public void UserLogin(IWebDriver driver, string userEmail, string password)
        {
            SignInPage signInPage = new SignInPage(driver);

            signInPage.GoToUrl();
            signInPage.SendKeysToEmailField(userEmail)
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
            Thread.Sleep(1000);  //TODO: change to wait until
        }

        public void UserLogout(string userEmail)
        {
            DBCleanup.DeleteLastTokenOfUserByEmail(userEmail);
        }

    }
}