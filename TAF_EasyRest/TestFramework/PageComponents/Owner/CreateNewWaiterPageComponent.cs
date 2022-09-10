namespace TestFramework.PageComponents
{
    public class CreateNewWaiterPageComponent 
    {
        IWebDriver driver { get; }

        public CreateNewWaiterPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _nameField => driver.FindElement(By.Name("name"));
        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _phoneNumberField => driver.FindElement(By.Name("phone_number"));
        private IWebElement _addButton => driver.FindElement(By.XPath("//span[contains(text(),'Add')]/parent::button"));
        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));

        public CreateNewWaiterPageComponent SendKeysToFields(string name, string email, string password, string phonenumber)
        {
            SendKeysToNameField(name);
            SendKeysToEmailField(email);
            SendKeysToPasswordField(password);
            SendKeysToPhoneNumberField(phonenumber);
            return this;
        }
        public ManageWaitersPage ClickAddButton(int timeToWait)
        {
            _addButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//li/parent::ul/parent::div")));
            return new ManageWaitersPage(driver);
        }
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
            _addButton.Click();
            return new CreateNewWaiterPageComponent(driver); 
        }
        public CreateNewWaiterPageComponent ClickCancelRegistrationWaiterButton()
        {
            _cancelButton.Click();
            return new CreateNewWaiterPageComponent(driver);
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

