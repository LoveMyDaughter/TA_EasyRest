namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class SignInSignUpHeaderButtonsPageComponent
    {
        IWebDriver driver { get; }

        public SignInSignUpHeaderButtonsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _signIn => driver.FindElement(By.XPath("//span[text()='Sign In']"));
        private IWebElement _signUp => driver.FindElement(By.XPath("//span[text()='Sign Up']"));

        public SignInPage ClickSignInButton()
        {
            _signIn.Click();
            return new SignInPage(driver);
        }

        public SignUpPage ClickSignUpButton()
        {
            _signUp.Click();
            return new SignUpPage(driver);
        }
    }
}
