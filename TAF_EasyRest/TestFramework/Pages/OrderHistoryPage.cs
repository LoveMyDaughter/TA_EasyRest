using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents;

namespace TestFramework.Pages
{
    public class OrderHistoryPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }

        public OrderHistoryPage(IWebDriver driver): base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
        }

        #region Elements

        private IWebElement _allButton => driver.FindElement(By.XPath("//span[contains(text(),'All')]/ancestor::a"));
        private IWebElement _historyButton => driver.FindElement(By.XPath("//span[contains(text(),'History (')]/ancestor::a"));
        private IWebElement _declinedButton => driver.FindElement(By.XPath("//span[contains(text(),'Declined')]/ancestor::a"));
        private IWebElement _orderField => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-1340']/child::div)[1]"));
        private IWebElement _reorderButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-1340']/child::div)[1]//button"));

        //add other buttons, when they will be needed

        #endregion

        #region Methods

        public OrderHistoryPage ClickAllButton()
        {
            _allButton.Click();
            return this;
        }

        public OrderHistoryPage ClickHistoryButton()
        {
            _historyButton.Click();
            return this;
        }

        public OrderHistoryPage ClickDeclineButton()
        {
            _declinedButton.Click();
            return this;
        }

        public OrderHistoryPage ExpandOrderField()
        {
            _orderField.Click();
            return this;
        }

        public OrderHistoryPage ClickReorderButton()
        {
            _reorderButton.Click();
            return this;
        }

        #endregion
    }
}
