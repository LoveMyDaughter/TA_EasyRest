using TestFramework.PageComponents.Moderator;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class ModeratorPanelRestaurantsPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public ModeratorPanelPageComponent ModeratorLeftsideMenu { get; }


        public ModeratorPanelRestaurantsPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
            ModeratorLeftsideMenu = new ModeratorPanelPageComponent(driver);

         }


        #region Elements

        private IWebElement _unapprovedTab => driver.FindElement(By.XPath("//span[contains (text() , 'Unapproved')]/ancestor::button"));
        private IWebElement _archivedTab => driver.FindElement(By.XPath("//span[contains (text() , 'Archived')]/ancestor::button"));

        #endregion


        #region Methods

        public UnapprovedRestaurantsPageComponent ClickUnapprovedTab()
        {
            _unapprovedTab.Click();
            return new UnapprovedRestaurantsPageComponent(driver);
        }

        public ArchivedRestaurantsPageComponent ClickArchivedTab()
        {
            _unapprovedTab.Click();
            return new ArchivedRestaurantsPageComponent(driver);
        }

        #endregion

    }
}
