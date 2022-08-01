using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class AdminPanelCreateModeratorPage : BasePage
    {
        public AdminPanelPageComponent AdminLeftsideMenu { get; }
        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }

        public AdminPanelCreateModeratorPage (IWebDriver driver) : base(driver)
        {
            AdminLeftsideMenu = new AdminPanelPageComponent(driver);
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
        }

        #region Elements

        private IWebElement _nameField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement _emailField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement _phoneNumberField => driver.FindElement(By.XPath("//input[@name='phoneNumber']"));
        private IWebElement _birthDateField => driver.FindElement(By.XPath("//input[@name='birthDate']"));
        private IWebElement _passwordField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement _repeatedPasswordField => driver.FindElement(By.XPath("//input[@name='repeated_password']"));
        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[text() = 'Cancel']/parent::a"));
        private IWebElement _createAccountButton => driver.FindElement(By.XPath("//span[text() = 'Create account']/parent::button"));

        #endregion



        #region Methods

        public AdminPanelCreateModeratorPage ClickNameField()
        {
            _nameField.Click();
            return this;
        }        
        
        public AdminPanelCreateModeratorPage ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public AdminPanelCreateModeratorPage ClickPasswordrField()
        {
            _passwordField.Click();
            return this;
        }

        public AdminPanelCreateModeratorPage ClickRepeatedPasswordField()
        {
            _repeatedPasswordField.Click();
            return this;
        }


        public AdminPanelCreateModeratorPage SendKeysToNameField(string name)
        {
            _nameField.SendKeys(name);
            return this;
        }

        public AdminPanelCreateModeratorPage SendKeysToEmailField(string email)
        {
            _emailField.SendKeys(email);
            return this;
        }

        public AdminPanelCreateModeratorPage SendKeysToPasswordField(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }

        public AdminPanelCreateModeratorPage SendKeysToRepeatedPasswordField(string password)
        {
            _repeatedPasswordField.SendKeys(password);
            return this;
        }

        public AdminPanelModeratorsPage ClickCreateAccountButton()
        {
            _createAccountButton.Click();
            return new AdminPanelModeratorsPage(driver);
        }

        #endregion

    }
}
