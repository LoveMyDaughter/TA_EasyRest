using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class CurrentOrdersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
        public List<WaitingForConfirmOrderPageComponent> orders { get; set; }
        private static string _pageUrl = "/profile/current_orders/";

        public CurrentOrdersPage(IWebDriver driver) : base(driver)
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
            FillOdersList();
        }


        private IWebElement _allButton => driver.FindElement(By.XPath("//span[contains(text(),'All')]/parent::span/parent::span/parent::a"));
        private IWebElement _waitingForConfirmButton => driver.FindElement(By.XPath("//span[contains(text(),'Waiting for confirm')]/parent::span/parent::span/parent::a"));

        public int CountOrders()
        {
            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.XPath("//div[contains(@class,'MuiExpansionPanel-rounded')]"));
            return items.Count();
        }

        private void FillOdersList()
        {
            int countOrders = СountOrders();

            orders = new List<WaitingForConfirmOrderPageComponent>();
            for (int i = 0; i < countOrders; i++)
            {
                orders.Add(new WaitingForConfirmOrderPageComponent(driver, (i + 1)));
            }
        }

        public CurrentOrdersPage ClickAllButton()
        {
            _allButton.Click();
            FillOdersList();
            return this;
        }


        public CurrentOrdersPage ClickWaitingForConfirmButton()
        {
            _waitingForConfirmButton.Click();
            FillOdersList();
            return this;
        }

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }
    }
}