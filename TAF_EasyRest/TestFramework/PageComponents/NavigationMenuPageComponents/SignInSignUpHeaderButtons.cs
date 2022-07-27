using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.PageComponents.NavigationMenuComponents
{
    internal class SignInSignUpHeaderButtons
    {
        IWebDriver driver { get; set; }

        public SignInSignUpHeaderButtons(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _SignIn => driver.FindElement(By.XPath("//span[text()='Sign In']"));
        private IWebElement _SignUp => driver.FindElement(By.XPath("//span[text()='Sign Up']"));

        public SignInPage ClickOnSignInButton()
        {
            _SignIn.Click();
            return new SignInPage(driver);
        }

        public SignUpPage ClickOnSignUpButton()
        {
            _SignUp.Click();
            return new SignUpPage(driver);
        }
    }
}
