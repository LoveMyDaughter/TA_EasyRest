using TestFramework.Tools;
namespace TestFramework.Test
{
    public class BaseTest
    {
        protected string userEmail;
        protected string userPassword;

        public void UserLogin(IWebDriver driver, string userEmail, string password)
        {
            SignInPage signInPage = new SignInPage(driver);

            signInPage.GoToUrl();
            signInPage.SendKeysToEmailField(userEmail)
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
            string currentUrl = driver.Url;
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => driver.Url != currentUrl);
        }

        public void UserLogout(string userEmail)
        {
            DBCleanup.DeleteLastTokenOfUserByEmail(userEmail);
        }

    }
}