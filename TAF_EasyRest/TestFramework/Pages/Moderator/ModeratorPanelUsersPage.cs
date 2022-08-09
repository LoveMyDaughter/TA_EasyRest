using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Moderator;

namespace TestFramework.Pages.Moderator
{
    public class ModeratorPanelUsersPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public ModeratorPanelPageComponent ModeratorLeftsideMenu { get; }


        public ModeratorPanelUsersPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
            ModeratorLeftsideMenu = new ModeratorPanelPageComponent(driver);
        }

        private IReadOnlyCollection<IWebElement> _usersList => driver.FindElements(By.XPath("//tbody/tr"));



        #region Methods

        // Find a button to ban/unban the first user in the list and click it
        public ModeratorPanelUsersPage FindAndClickPadlockButton()
        {
            var firstUserFromList = _usersList.ElementAt(0);
            var padlockButton = firstUserFromList.FindElement(By.XPath("./td/button"));

            padlockButton.Click();

            return this;
        }

        // With this method we'll check if user status changes after click on padlockButton
        public string ShowUserStatus()
        {
            var firstUserFromList = _usersList.ElementAt(0);
            var userStatusLabel = firstUserFromList.FindElement(By.XPath("./td/p"));
            string userStatus = userStatusLabel.Text;

            return userStatus;
        }

        #endregion

    }
}
