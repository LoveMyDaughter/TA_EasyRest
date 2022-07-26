
namespace TestFramework.Pages
{
    public class SignInPage : BasePage
    {
        private static string _signInUrl = "/log-in";

        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _logInButton => driver.FindElement(By.XPath("//span[text()='Sign In']/parent::button"));


        public SignInPage(IWebDriver driver) : base(driver) { }

        public SignInPage ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public SignInPage ClickPasswordField()
        {
            _passwordField.Click();
            return this;
        }

        public SignInPage SendKeysToEmailField(string email)
        {
            _emailField.SendKeys(email);
            return this;
        }

        public SignInPage SendKeysToPasswordField(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }

        public SignInPage ClickSignInButton()
        {
            _logInButton.Click();
            return this;
        }

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _signInUrl);
        }
    }
}
