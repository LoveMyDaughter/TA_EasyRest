
namespace TestFramework.Pages
{
    public class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver) { }

        private IWebElement _personalInfoButton => driver.FindElement(By.XPath("//span[text()='Personal Info']/parent::span/parent::span/parent::a"));
        private IWebElement _currentOrdersButton => driver.FindElement(By.XPath("//span[text()='Current Orders']/parent::span/parent::span/parent::a"));
        private IWebElement _orderHistoryButton => driver.FindElement(By.XPath("//span[text()='Order History']/parent::span/parent::span/parent::a"));
        private IWebElement _myRestaurantsButton => driver.FindElement(By.XPath("//span[text()='My Restaurants']/parent::span/parent::span/parent::a"));

        public PersonalInfoPage PersonalInfoButtonClick()
        {
            _personalInfoButton.Click();
            return this;
        }

        public PersonalInfoPage СurrentOrdersButtonClick()
        {
            _currentOrdersButton.Click();
            return this;
        }

        public PersonalInfoPage OrderHistoryButtonClick()
        {
            _orderHistoryButton.Click();
            return this;
        }

        public PersonalInfoPage MyRestaurantsButtonClick()
        {
            _myRestaurantsButton.Click();
            return this;
        }
    }
}