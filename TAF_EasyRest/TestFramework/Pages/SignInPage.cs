using TestFramework.PagesComponents;

namespace TestFramework.Pages
{
    public class SignInPage : BasePage
    {
        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _logInButton => driver.FindElement(By.XPath("//span[text()='Sign In']/parent::button"));

        public NavigationMenuPageComponent NavigationMenu { get; set; }

        public SignInPage(IWebDriver driver) : base(driver) 
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }

        public SignInPage GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(baseUrl + url);
            return this;
        }

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
    }
}
