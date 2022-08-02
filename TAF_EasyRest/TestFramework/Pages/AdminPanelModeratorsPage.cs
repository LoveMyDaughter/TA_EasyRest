using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class AdminPanelModeratorsPage : BasePage
    {

        public AdminPanelPageComponent AdminLeftsideMenu { get; }
        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }


        public AdminPanelModeratorsPage(IWebDriver driver) : base(driver)
        {
            AdminLeftsideMenu = new AdminPanelPageComponent(driver);
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
        }


        #region Elements

        private IWebElement _addModeratorButton => driver.FindElement(By.XPath("//*[@id = 'root']/div/main/a"));

        // Table body with the list of moderators. This is a parent for any moderator line
        private IWebElement _moderatorsList => driver.FindElement(By.XPath("//tbody"));


        // These elements are only available inside the _moderatorsList component
        private IWebElement _statusRecord(string username) => driver.FindElement(By.XPath($"//th[text()='{username}']/following-sibling::td/p"));
        private IWebElement _padlockButtonForUser(string username) => driver.FindElement(By.XPath($"//th[text()='{username}']/following-sibling::td/button"));

        #endregion


        #region Methods

        public AdminPanelModeratorsPage ClickPadlockButton(string username)
        {
            _padlockButtonForUser(username).Click();
            return this;
            // Add exception: User not found
        }

        // "Active" or "Banned" status for required user - to check if user's activity changes
        public string StatusRecordGetText(string username)
        {
            return _statusRecord(username).Text;
            // Add exception: User not found
        }

        public AdminPanelCreateModeratorPage ClickAddModeratorButton()
        {
            _addModeratorButton.Click();
            return new AdminPanelCreateModeratorPage(driver);
        }

        #endregion


    }
}