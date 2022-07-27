
namespace TestFramework.PageComponents
{
    public class ManageWa : BasePage
    {
        public ManageWa(IWebDriver driver) : base(driver) { }

        protected IWebElement _personalInfoButton => driver.FindElement(By.XPath("//span[text()='Personal Info']/parent::span/parent::span/parent::a"));
        protected IWebElement _currentOrdersButton => driver.FindElement(By.XPath("//span[text()='Current Orders']/parent::span/parent::span/parent::a"));
        protected IWebElement _orderHistoryButton => driver.FindElement(By.XPath("//span[text()='Order History']/parent::span/parent::span/parent::a"));
        protected IWebElement _myRestaurantsButton => driver.FindElement(By.XPath("//span[text()='My Restaurants']/parent::span/parent::span/parent::a"));

        public ManageWa ClickPersonalInfoButton()
        {
            _personalInfoButton.Click();
            return this;
        }

        public ManageWa ClickСurrentOrdersButton()
        {
            _currentOrdersButton.Click();
            return this;
        }

        public ManageWa ClickOrderHistoryButton()
        {
            _orderHistoryButton.Click();
            return this;
        }

        public ManageWa ClickMyRestaurantsButton()
        {
            _myRestaurantsButton.Click();
            return this;
        }
    }
}