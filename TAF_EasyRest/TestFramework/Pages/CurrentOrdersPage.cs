using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class CurrentOrdersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
        public List<WaitingForConfirmOrderPageComponent> orders { get; set; }

        public CurrentOrdersPage(IWebDriver driver) : base(driver)
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            FillOdersList();
        }


        private IWebElement _allButton => driver.FindElement(By.XPath("//span[contains(text(),'All')]/parent::span/parent::span/parent::a"));
        private IWebElement _waitingForConfirmButton => driver.FindElement(By.XPath("//span[contains(text(),'Waiting for confirm')]/parent::span/parent::span/parent::a"));

        private int СountOrders()
        {
            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.XPath("//div[@class='MuiButtonBase-root-106 MuiExpansionPanelSummary-root-573']"));
            return items.Count();
        }

        private void FillOdersList()
        {
            orders = new List<WaitingForConfirmOrderPageComponent>(СountOrders());
            for (int i = 0; i < orders.Count; i++)
            {
                orders.Add(new WaitingForConfirmOrderPageComponent(driver, (i + 1)));
            }
        }

        public CurrentOrdersPage ClickAllButton()
        {
            FillOdersList();
            _allButton.Click();
            return this;
        }


        public CurrentOrdersPage ClickWaitingForConfirmButton()
        {
            FillOdersList();
            _waitingForConfirmButton.Click();
            return this;
        }

    }
}