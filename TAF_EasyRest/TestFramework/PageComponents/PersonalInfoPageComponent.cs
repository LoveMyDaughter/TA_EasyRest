
namespace TestFramework.PageComponents
{
    public class PersonalInfoPageComponent : BasePage
    {
        public PersonalInfoPageComponent(IWebDriver driver) : base(driver) { }

        protected IWebElement _personalInfoButton => driver.FindElement(By.XPath("//span[text()='Personal Info']/parent::span/parent::span/parent::a"));
        protected IWebElement _currentOrdersButton => driver.FindElement(By.XPath("//span[text()='Current Orders']/parent::span/parent::span/parent::a"));
        protected IWebElement _orderHistoryButton => driver.FindElement(By.XPath("//span[text()='Order History']/parent::span/parent::span/parent::a"));
        protected IWebElement _myRestaurantsButton => driver.FindElement(By.XPath("//span[text()='My Restaurants']/parent::span/parent::span/parent::a"));

        public PersonalInfoPageComponent ClickPersonalInfoButton()
        {
            _personalInfoButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickСurrentOrdersButton()
        {
            _currentOrdersButton.Click();
            return new CurrentOrdersPage(driver);
        }

        public OrderHistoryPage ClickOrderHistoryButton()
        {
            _orderHistoryButton.Click();
            return new OrderHistoryPage(driver);
        }

        public NewRestaurantPage ClickMyRestaurantsButton()
        {
            _myRestaurantsButton.Click();
            return new NewRestaurantPage(driver);
        }
    }
}