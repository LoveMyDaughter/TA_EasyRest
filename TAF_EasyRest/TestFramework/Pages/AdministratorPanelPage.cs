using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class AdministratorPanelPage : BasePage
    {
        NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        UserMenuHeaderButtonPageComponent UserMenuHeaderButton { get; }
        

        public AdministratorPanelPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            UserMenuHeaderButtonPageComponent UserMenuHeaderButton = new UserMenuHeaderButtonPageComponent(driver);
        }

        private IWebElement _waitingForConfirmButton => driver.FindElement(By.XPath("//header//span[text()='Waiting for confirm']"));
        private IWebElement _acceptedButton => driver.FindElement(By.XPath("//header//span[text()='Accepted']"));

        public WaitingForConfirmTabPageComponent ClickWaitingForConfirmButton()
        {
            _waitingForConfirmButton.Click();
            return new WaitingForConfirmTabPageComponent(driver);
        }

        public AcceptedTabPageComponent ClickAcceptedButton()
        {
            _acceptedButton.Click();
            return new AcceptedTabPageComponent(OrdersContainer);
        }

    }
}
