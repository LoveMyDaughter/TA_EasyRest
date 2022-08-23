using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

using TestFramework.Tools.GetData; 

namespace TestFramework.Pages
{
    public class CurrentOrdersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
        public List<WaitingForConfirmOrderPageComponent> orders { get; set; }
        private static string _pageUrl => GetUrls.getUrl("CurrentOrdersPage").Url;

        public CurrentOrdersPage(IWebDriver driver) : base(driver)
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
        }


        private By _allButton => By.XPath("//span[contains(text(),'All')]/parent::span/parent::span/parent::a");
        private By _waitingForConfirmButton => By.XPath("//span[contains(text(),'Waiting for confirm')]/parent::span/parent::span/parent::a");

        public int CountOrders(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(By.XPath("//div[contains(@class,'UserOrders-root')]"), timeToWait);
            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.XPath("//div[contains(@class,'MuiExpansionPanel-rounded')]"));
            return items.Count();
        }

        private void FillOdersList()
        {
            int countOrders = CountOrders(3);

            orders = new List<WaitingForConfirmOrderPageComponent>();
            for (int i = 0; i < countOrders; i++)
            {
                orders.Add(new WaitingForConfirmOrderPageComponent(driver, (i + 1)));
            }
        }

        public CurrentOrdersPage ClickAllButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_allButton, timeToWait);
            FillOdersList();
            return this;
        }


        public CurrentOrdersPage ClickWaitingForConfirmButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_waitingForConfirmButton, timeToWait)
                .Click();
            FillOdersList();
            return this;
        }

        public override void GoToUrl()
        {
            driver.WaitUntilUrlIsChanged();
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }
    }
}