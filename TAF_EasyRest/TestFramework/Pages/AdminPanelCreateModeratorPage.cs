namespace TestFramework.Pages
{
    public class AdminPanelCreateModeratorPage : BasePage
    {
        public AdminPanelPageComponent adminPanelPageComponent { get; }
        public AdminPanelCreateModeratorPage (IWebDriver driver) : base(driver)
        {
            adminPanelPageComponent = new AdminPanelPageComponent(driver);
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


        #endregion

    }
}
