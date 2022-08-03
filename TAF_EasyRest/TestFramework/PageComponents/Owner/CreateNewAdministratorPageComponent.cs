namespace TestFramework.PageComponents
{
    public class CreateNewAdministratorPageComponent
    {
        IWebDriver driver { get; }

        public CreateNewAdministratorPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _nameField => driver.FindElement(By.Name("name"));
        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _phoneNumberField => driver.FindElement(By.Name("phone_number"));
        private IWebElement _addButton => driver.FindElement(By.XPath("//span[contains(text(),'Add')]/parent::button"));
        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));

        public CreateNewAdministratorPageComponent ClickNameField()
        {
            _nameField.Click();
            return this;
        }
        public CreateNewAdministratorPageComponent ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public CreateNewAdministratorPageComponent ClickPasswordField()
        {
            _passwordField.Click();
            return this;
        }
        public CreateNewAdministratorPageComponent ClickPhoneNumberField()
        {
            _phoneNumberField.Click();
            return this;
        }
        public CreateNewAdministratorPageComponent ClickAddButton()
        {
            _addButton.Click();
            return new CreateNewAdministratorPageComponent(driver);
        }
        public CreateNewAdministratorPageComponent ClickCancelButton()
        {
            _cancelButton.Click();
            return new CreateNewAdministratorPageComponent(driver);
        }
        public CreateNewAdministratorPageComponent SendKeysToNameField(string name)
        {
            _nameField.SendKeys(name);
            return this;
        }
        public CreateNewAdministratorPageComponent SendKeysToEmailField(string email)
        {
            _emailField.SendKeys(email);
            return this;
        }

        public CreateNewAdministratorPageComponent SendKeysToPasswordField(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }
        public CreateNewAdministratorPageComponent SendKeysToPhoneNumberField(string phone_number)
        {
            _phoneNumberField.SendKeys(phone_number);
            return this;
        }
    }
}
