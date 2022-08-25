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

        public CreateNewAdministratorPageComponent SendKeysToFields(string name, string email, string password, string phonenumber)
        {
            SendKeysToNameField(name);
            SendKeysToEmailField(email);
            SendKeysToPasswordField(password);
            SendKeysToPhoneNumberField(phonenumber);
            return this;
        }

        public ManageAdministratorPage ClickAddButton()
        {
            _addButton.Click();
            Thread.Sleep(3000); // change to waiter
            return new ManageAdministratorPage(driver);
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
