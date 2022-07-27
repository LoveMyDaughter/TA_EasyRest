using TestFramework.PageComponents;
namespace TestFramework.Pages
{
    internal class ManageWaitersPage : BasePage
    {
        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
            personalInfoPageComponent = new PersonalInfoPageComponent(driver);
        }
        public PersonalInfoPageComponent personalInfoPageComponent { get; }

        private IWebElement _removeWaiterButton(string username) => driver.FindElement(By.XPath($"//span[contains(text(), '{username}')]/parent::div//following-sibling::button"));
        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//*[@id='root']/div/main/div[2]/button"));
        private IWebElement _nameField => driver.FindElement(By.Name("name"));
        private IWebElement _emailField => driver.FindElement(By.Name("email"));
        private IWebElement _passwordField => driver.FindElement(By.Name("password"));
        private IWebElement _phoneNumberField => driver.FindElement(By.Name("phone_number"));
        private IWebElement _addToSubmitRegistrationWaiterButton => driver.FindElement(By.XPath("//span[contains(text(),'Add')]/parent::button"));
        private IWebElement _cancelRegistrationWaiterButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));


        public ManageWaitersPage GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(baseUrl + url);
            return this;
        }

        public ManageWaitersPage ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            return this;
        }
        public ManageWaitersPage ClickNameField()
        {
            _nameField.Click();
            return this;
        }
        public ManageWaitersPage ClickEmailField()
        {
            _emailField.Click();
            return this;
        }

        public ManageWaitersPage ClickPasswordField()
        {
            _passwordField.Click();
            return this;
        }
        public ManageWaitersPage ClickPhoneNumberField()
        {
            _phoneNumberField.Click();
            return this;
        }
        public ManageWaitersPage ClickAddToSubmitRegistrationWaiterButton()
        {
            _addToSubmitRegistrationWaiterButton.Click();
            return this;
        }
        public ManageWaitersPage ClickCancelRegistrationWaiterButton()
        {
            _cancelRegistrationWaiterButton.Click();
            return this;
        }
        public ManageWaitersPage SendKeysToNameField(string name)
        {
            _nameField.SendKeys(name);
            return this;
        }
        public ManageWaitersPage SendKeysToEmailField(string email)
        {
            _emailField.SendKeys(email);
            return this;
        }

        public ManageWaitersPage SendKeysToPasswordField(string password)
        {
            _passwordField.SendKeys(password);
            return this;
        }
        public ManageWaitersPage SendKeysToPhoneNumberField(string phone_number)
        {
            _phoneNumberField.SendKeys(phone_number);
            return this;
        }
    }
}
