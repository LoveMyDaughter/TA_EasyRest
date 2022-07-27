namespace TestFramework.PageComponents
{
    public class CreateNewWaiterPageComponent : BasePage
    {
        public CreateNewWaiterPageComponent(IWebDriver driver) : base(driver) { }

        private IWebElement _nameField => driver.FindElement(By.Name("name"));
        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _phoneNumberField => driver.FindElement(By.Name("phone_number"));
        private IWebElement _addToSubmitRegistrationWaiterButton => driver.FindElement(By.XPath("//span[contains(text(),'Add')]/parent::button"));
        private IWebElement _cancelRegistrationWaiterButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));


        public CreateNewWaiterPageComponent ClickNameField()
        {
            _nameField.Click();
            return this;
        }
        public CreateNewWaiterPageComponent ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public CreateNewWaiterPageComponent ClickPasswordField()
        {
            _passwordField.Click();
            return this;
        }
        public CreateNewWaiterPageComponent ClickPhoneNumberField()
        {
            _phoneNumberField.Click();
            return this;
        }
        public CreateNewWaiterPageComponent ClickAddToSubmitRegistrationWaiterButton()
        {
            _addToSubmitRegistrationWaiterButton.Click();
            return this;
        }
        public CreateNewWaiterPageComponent ClickCancelRegistrationWaiterButton()
        {
            _cancelRegistrationWaiterButton.Click();
            return this;
        }
        public CreateNewWaiterPageComponent SendKeysToNameField(string name)
        {
            _nameField.SendKeys(name);
            return this;
        }
        public CreateNewWaiterPageComponent SendKeysToEmailField(string email)
        {
            _emailField.SendKeys(email);
            return this;
        }

        public CreateNewWaiterPageComponent SendKeysToPasswordField(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }
        public CreateNewWaiterPageComponent SendKeysToPhoneNumberField(string phone_number)
        {
            _phoneNumberField.SendKeys(phone_number);
            return this;
        }
    }
}

