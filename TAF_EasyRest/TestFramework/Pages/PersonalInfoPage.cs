
namespace TestFramework.Pages
{
    public class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver) { }

        private IWebElement _personalInfoButton => driver.FindElement(By.XPath("//span[text()='Personal Info']/parent::span/parent::span/parent::a"));
        private IWebElement _currentOrders => driver.FindElement(By.XPath("//span[text()='Current Orders']/parent::span/parent::span/parent::a"));
        private IWebElement _orderHistory => driver.FindElement(By.XPath("//span[text()='Order History']/parent::span/parent::span/parent::a"));
        private IWebElement _myRestaurants => driver.FindElement(By.XPath("//span[text()='My Restaurants']/parent::span/parent::span/parent::a"));
    }
}