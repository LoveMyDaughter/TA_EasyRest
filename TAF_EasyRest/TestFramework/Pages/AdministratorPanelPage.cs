using TestFramework.PageComponents.AdministratorPanelComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class AdministratorPanelPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public UserMenuHeaderButtonPageComponent UserMenuHeaderButton { get; }
        

        public AdministratorPanelPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            UserMenuHeaderButtonPageComponent UserMenuHeaderButton = new UserMenuHeaderButtonPageComponent(driver);
        }

        private IWebElement _waitingForConfirmButton => driver.FindElement(By.XPath("//header//span[text()='Waiting for confirm']"));
        private IWebElement _acceptedButton => driver.FindElement(By.XPath("//header//span[text()='Accepted']"));

        public WaitingForConfirmListPageComponent ClickWaitingForConfirmButton()
        {
            _waitingForConfirmButton.Click();
            return new WaitingForConfirmListPageComponent(driver);
        }

        public AcceptedListPageComponent ClickAcceptedButton()
        {
            _acceptedButton.Click();
            return new AcceptedListPageComponent(driver);
        }
    }
}
