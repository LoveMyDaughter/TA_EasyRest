using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Moderator;

namespace TestFramework.Pages.Moderator
{
    public class ModeratorPanelOwnersPage : BasePage
    {
        private static string _pageUrl = "/moderator/owners";
        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public ModeratorPanelPageComponent ModeratorLeftsideMenu { get; }


        public ModeratorPanelOwnersPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
            ModeratorLeftsideMenu = new ModeratorPanelPageComponent(driver);
        }

        private IReadOnlyCollection<IWebElement> _ownersList => driver.FindElements(By.XPath("//tbody/tr"));


        #region Methods

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }

        // Find a button to ban/unban the first owner in the list and click it
        public ModeratorPanelOwnersPage FindAndClickPadlockButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            string ownerStatus = ShowOwnerStatus();

            var firstOwnerFromList = _ownersList.ElementAt(0);
            var padlockButton = firstOwnerFromList.FindElement(By.XPath("./td/button"));
            padlockButton.Click();
            wait.Until(d => ShowOwnerStatus() != ownerStatus);

            return this;
        }

        // With this method we'll check if owner status changes after click on padlockButton
        public string ShowOwnerStatus()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => _ownersList.Count > 0);

            var firstOwnerFromList = _ownersList.ElementAt(0);
            var ownerStatusLabel = firstOwnerFromList.FindElement(By.XPath("./td/p[contains (@class, 'color')]"));
            string ownerStatus = ownerStatusLabel.Text;

            return ownerStatus;
        }

        #endregion


    }
}
