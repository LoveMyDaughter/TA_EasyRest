using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    internal class SignUpPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; set; }

        public SignUpPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }

        private IWebElement _nameField => driver.FindElement(By.XPath("//input [@name='name']"));
        private IWebElement _emailField => driver.FindElement(By.XPath("//input [@name='email']"));
        private IWebElement _phoneNumberField => driver.FindElement(By.XPath("//input [@name='phoneNumber']"));
        private IWebElement _birthDateField => driver.FindElement(By.XPath("//input [@name='birthDate']"));
        private IWebElement _passwordField => driver.FindElement(By.XPath("//input [@name='password']"));
        private IWebElement _confirmPasswordField => driver.FindElement(By.XPath("//input [@name='repeated_password']"));
        private IWebElement _createAccountButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public SignUpPage ClickNameField()
        {
            _nameField.Click();
            return this;
        }

        public SignUpPage ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public SignUpPage ClickPhoneNumberField()
        {
            _phoneNumberField.Click();
            return this;
        }

        public SignUpPage ClickBirthDateField()
        {
            _birthDateField.Click();
            return this;
        }

        public SignUpPage ClickPasswordField()
        {
            _passwordField.Click();
            return this;
        }

        public SignUpPage ClickConfirmPasswordField()
        {
            _confirmPasswordField.Click();
            return this;
        }

        public SignUpPage ClickCreateAccountButton()
        {
            _createAccountButton.Click();
            return this;
        }
    }
}
