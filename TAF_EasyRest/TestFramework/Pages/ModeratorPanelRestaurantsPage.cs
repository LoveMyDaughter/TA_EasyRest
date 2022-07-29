using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class ModeratorPanelRestaurantsPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }

        public AdminPanelPageComponent AdminPanelPageComponent { get; }

        public List<UnapprovedRestaurantPageComponent> restaurants { get; set; }


        public ModeratorPanelRestaurantsPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            
            // Panel's button "Moderators" is not visible on the current page. We don't use it
            AdminPanelPageComponent = new AdminPanelPageComponent(driver);

            FillRestaurantsGrid();
        }


        #region Elements

        // Top-line tab-buttons: All, Unapproved, Approved, Archived
        private IWebElement _allTabButton;
        private IWebElement _unapprovedTabButton => driver.FindElement(By.XPath("//span[contains (text() , 'Unapproved')]/ancestor::button"));
        private IWebElement _approvedTabButton => driver.FindElement(By.XPath("//span[contains (text() , 'Approved')]/ancestor::button"));
        private IWebElement _archivedTabButton => driver.FindElement(By.XPath("//span[contains (text() , 'Archived')]/ancestor::button"));


        // Change restaurant status buttons
        private IWebElement _deleteButton => driver.FindElement(By.XPath("//span[text() = 'Delete']/parent::button"));
        private IWebElement _approveButton => driver.FindElement(By.XPath("//span[text() = 'Approve']/parent::button"));
        private IWebElement _restoreButton => driver.FindElement(By.XPath("//span[text() = 'Restore']/parent::button"));

        #endregion


        #region Methods

        private void FillRestaurantsGrid()
        {
            restaurants = new List<UnapprovedRestaurantPageComponent>(СountRestaurants());
            for (int i = 0; i < restaurants.Count; i++)
            {
                restaurants.Add(new UnapprovedRestaurantPageComponent(driver));
            }
        }

        private int СountRestaurants()
        {
            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.XPath("//div[contains(@class, 'Grid-grid')]']"));
            return items.Count();
        }
    

    public ModeratorPanelRestaurantsPage ClickUnapprovedTabButton()
        {
            _unapprovedTabButton.Click();
            return this;
        }
        public ModeratorPanelRestaurantsPage ClickApprovedTabButton()
        {
            _approvedTabButton.Click();
            return this;
        }
        public ModeratorPanelRestaurantsPage ClickArchivedTabButton()
        {
            _archivedTabButton.Click();
            return this;
        }


        public ModeratorPanelRestaurantsPage ClickDeleteButton()
        {
            _deleteButton.Click();
            return this;
        }

        public ModeratorPanelRestaurantsPage ClickApproveButton()
        {
            _approveButton.Click();
            return this;
        }

        public ModeratorPanelRestaurantsPage ClickRestoreButton()
        {
            _restoreButton.Click();
            return this;
        }

        #endregion

    }
}
