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

        /// <summary>
        /// Find a button to ban/unban the first moderator in the list and click it
        /// </summary>
        public AdminPanelModeratorsPage FindAndClickPadlockButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            string status = GetModeratorStatus();

            var firstModeratorFromList = _moderatorsList.ElementAt(0);
            var padlockButton = firstModeratorFromList.FindElement(By.XPath("./td/button"));
            padlockButton.Click();
            wait.Until(d => GetModeratorStatus() != status);

            return this;
        }

        /// <summary>
        /// With this method we'll check if moderator status changes after click on padlockButton
        /// </summary>
        public string GetModeratorStatus()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => _moderatorsList.Count > 0);

            var firstModeratorFromList = _moderatorsList.ElementAt(0);
            var moderatorStatusLabel = firstModeratorFromList.FindElement(By.XPath("./td/p"));
            string moderatorStatus = moderatorStatusLabel.Text;
            return moderatorStatus;
        }

        public AdminPanelCreateModeratorPage ClickAddModeratorButton()
        {
            _addModeratorButton.Click();
            return new AdminPanelCreateModeratorPage(driver);
        }

        #endregion


    }
}