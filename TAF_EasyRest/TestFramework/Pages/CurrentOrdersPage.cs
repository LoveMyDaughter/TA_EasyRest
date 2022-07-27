using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class CurrentOrdersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }

        public CurrentOrdersPage(IWebDriver driver) : base(driver)
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        }


        private IWebElement _allButton => driver.FindElement(By.XPath("//span[contains(text(),'All')]/parent::span/parent::span/parent::a"));
        private IWebElement _draftButton => driver.FindElement(By.XPath("//span[contains(text(),'Draft')]/parent::span/parent::span/parent::a"));
        private IWebElement _waitingForConfirmButton => driver.FindElement(By.XPath("//span[contains(text(),'Waiting for confirm')]/parent::span/parent::span/parent::a"));
        private IWebElement _acceptedButton => driver.FindElement(By.XPath("//span[contains(text(),'Accepted')]/parent::span/parent::span/parent::a"));
        private IWebElement _assignedWaiterButton => driver.FindElement(By.XPath("//span[contains(text(),'Assigned waiter')]/parent::span/parent::span/parent::a"));
        private IWebElement _inProgressButton => driver.FindElement(By.XPath("//span[contains(text(),'In progress')]/parent::span/parent::span/parent::a"));
        private IWebElement _orderField => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-2528']/child::div)[1]"));
        private IWebElement _declineButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-2528']/child::div)[1]//button"));


        public CurrentOrdersPage ClickAllButton()
        {
            _allButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickDraftButton()
        {
            _draftButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickWaitingForConfirmButton()
        {
            _waitingForConfirmButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickAcceptedButton()
        {
            _acceptedButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickAssignedWaiterButton()
        {
            _assignedWaiterButton.Click();
            return this;
        }

        public CurrentOrdersPage ClickInProgressButton()
        {
            _inProgressButton.Click();
            return this;
        }

        public CurrentOrdersPage ExpandOrderField()
        {
            _orderField.Click();
            return this;
        }

        public CurrentOrdersPage ClickDeclineButton()
        {
            _declineButton.Click();
            return this;
        }
    }
}