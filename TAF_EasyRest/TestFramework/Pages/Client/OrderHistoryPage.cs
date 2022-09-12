using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.Tools.GetData;

namespace TestFramework.Pages
{
    public class OrderHistoryPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
        public List<OrderPageComponent> orders { get; set; }
        private string _pageUrl => GetUrls.getUrl("OrderHistoryPage").Url;

        public OrderHistoryPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);

        }

        #region Elements

        private By _allButton => By.XPath("//span[contains(text(),'All')]/ancestor::a");
        private By _historyButton => By.XPath("//span[contains(text(),'History (')]/ancestor::a");

        #endregion

        #region Methods

        public int CountOrders(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(By.XPath("//div[contains(@class,'MuiExpansionPanel-rounded')]"), timeToWait);

            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.XPath("//div[contains(@class,'MuiExpansionPanel-rounded')]"));
            return items.Count();
        }

        private void FillOdersList()
        {
            int countOrders = CountOrders(10);

            orders = new List<OrderPageComponent>();
            for (int i = 0; i < countOrders; i++)
            {
                orders.Add(new OrderPageComponent(driver, (i + 1)));
            }
        }

        public OrderHistoryPage ClickAllButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_allButton, timeToWait)
                .Click();
            FillOdersList();
            return this;
        }

        public OrderHistoryPage ClickHistoryButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_historyButton, timeToWait)
                .Click();
            FillOdersList();
            return this;
        }

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }

        #endregion
    }
}
