using TestFramework.PageComponents.NavigationMenuComponents;
namespace TestFramework.Pages.Moderator
{
    public class ModeratorPanelOwnersPage : BasePage
    {
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

        // Find a button to ban/unban the first owner in the list and click it
        public ModeratorPanelOwnersPage FindAndClickPadlockButton()
        {
            var firstOwnerFromList = _ownersList.ElementAt(0);
            var padlockButton = firstOwnerFromList.FindElement(By.XPath("./td/button"));

            padlockButton.Click();

            return this;
        }

        // With this method we'll check if owner status changes after click on padlockButton
        public string ShowOwnerStatus()
        {
            var firstOwnerFromList = _ownersList.ElementAt(0)
            var ownerStatusLabel = firstOwnerFromList.FindElement(By.XPath("./td/p"));
            string ownerStatus = ownerStatusLabel.Text;

            return ownerStatus;
        }

        #endregion


    }
}
