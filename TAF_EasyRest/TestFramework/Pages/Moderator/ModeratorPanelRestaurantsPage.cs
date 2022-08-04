using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class ModeratorPanelRestaurantsPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        public UserMenuHeaderButtonPageComponent UserButton { get; }
        public ModeratorPanelPageComponent ModeratorLeftsideMenu { get; }

        //public List<UnapprovedRestaurantPageComponent> restaurants { get; set; }
        private IReadOnlyCollection<IWebElement> _restaurantsGrid => driver.FindElements(By.XPath("//div[contains(@class, 'Grid-item')]"));


        public ModeratorPanelRestaurantsPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            UserButton = new UserMenuHeaderButtonPageComponent(driver);
            ModeratorLeftsideMenu = new ModeratorPanelPageComponent(driver);

         }


        #region Elements

        // Top-line tab-buttons: All, Unapproved, Approved, Archived. We need only 2 of them
        private IWebElement _unapprovedTab => driver.FindElement(By.XPath("//span[contains (text() , 'Unapproved')]/ancestor::button"));
        private IWebElement _archivedTab => driver.FindElement(By.XPath("//span[contains (text() , 'Archived')]/ancestor::button"));




        // Change restaurant status buttons. Move to corresponding components
        private IWebElement _approveButton => driver.FindElement(By.XPath("//span[text() = 'Approve']/parent::button"));
        private IWebElement _disapproveButton => driver.FindElement(By.XPath("//span[text() = 'Disapprove']/parent::button"));
        private IWebElement _restoreButton => driver.FindElement(By.XPath("//span[text() = 'Restore']/parent::button"));

        #endregion




        #region Methods
            

    public ModeratorPanelRestaurantsPage ClickUnapprovedTab()
        {
            _unapprovedTab.Click();
            return this;
        }

        public ModeratorPanelRestaurantsPage ClickArchivedTab()
        {
            _archivedTab.Click();
            return this;
        }


        #endregion

    }
}
