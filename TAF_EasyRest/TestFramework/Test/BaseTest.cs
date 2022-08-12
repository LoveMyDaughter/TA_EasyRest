namespace TestFramework.Test
{
    public class BaseTest
    {
        private static string baseUrl = "http://localhost:3000";

        public void UserLogin(IWebDriver driver, string userEmail, string password)
        {
            SignInPage signInPage = new SignInPage(driver);

            signInPage.GoToUrl();
            signInPage.SendKeysToEmailField(userEmail)
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
            Thread.Sleep(2000);
        }

    }
}