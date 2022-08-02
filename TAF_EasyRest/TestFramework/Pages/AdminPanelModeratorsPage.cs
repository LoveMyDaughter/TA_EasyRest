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

        private IReadOnlyCollection<IWebElement> _moderatorsList => driver.FindElements(By.XPath("//tbody/tr"));


        #region Elements

        private IWebElement _addModeratorButton => driver.FindElement(By.XPath("//*[@id = 'root']/div/main/a"));

        #endregion


        #region Methods

        // Find first row of the moderators list. Find button and status for it. Click button. Check if the status has changed
        public bool ChangeModeratorStatus()
        {
            var firstModeratorFromList = _moderatorsList.ElementAt(0);
            var padlockButton = firstModeratorFromList.FindElement(By.XPath("./td/button"));
            var statusRecord = firstModeratorFromList.FindElement(By.XPath("./td/p"));
            string startStatus = statusRecord.Text;

            padlockButton.Click();

            string endStatus = statusRecord.Text;

            return startStatus == endStatus;
        }

        public AdminPanelCreateModeratorPage ClickAddModeratorButton()
        {
            _addModeratorButton.Click();
            return new AdminPanelCreateModeratorPage(driver);
        }

        #endregion


    }
}