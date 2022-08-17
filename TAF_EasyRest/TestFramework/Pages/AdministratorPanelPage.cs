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
            UserMenuHeaderButton = new UserMenuHeaderButtonPageComponent(driver);
        }

        private By _waitingForConfirmButton = By.XPath("//header//span[text()='Waiting for confirm']");
        private By _acceptedButton = By.XPath("//header//span[text()='Accepted']");

        
        public WaitingForConfirmListPageComponent ClickWaitingForConfirmButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_waitingForConfirmButton, timeToWait)
                .Click();
            return new WaitingForConfirmListPageComponent(driver);
        }

        public AcceptedListPageComponent ClickAcceptedButton(int tomeToWait)
        {
            driver.WaitUntilElementIsVisible(_acceptedButton, tomeToWait)
                .Click();
            return new AcceptedListPageComponent(driver);
        }
    }
}
