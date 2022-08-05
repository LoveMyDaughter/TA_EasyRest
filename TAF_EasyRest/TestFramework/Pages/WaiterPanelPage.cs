using TestFramework.PageComponents.Waiter;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class WaiterPanelPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public UserMenuHeaderButtonPageComponent UserMenuHeaderButton { get; }


        public WaiterPanelPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            UserMenuHeaderButton = new UserMenuHeaderButtonPageComponent(driver);
        }

        private IWebElement _assignedWaiterButton => driver.FindElement(By.XPath("//header//span[contains (text(), 'Assigned waiter')]"));
        private IWebElement _inProgressButton => driver.FindElement(By.XPath("//header//span[contains (text(), 'In progress')]"));

        public AssignedWaiterListPageComponent ClickAssignedWaiterButton()
        {
            _assignedWaiterButton.Click();
            return new AssignedWaiterListPageComponent(driver);
        }

        public InProgressListPageComponent ClickInProgressButton()
        {
            _inProgressButton.Click();
            return new InProgressListPageComponent(driver);
        }
    }
}




