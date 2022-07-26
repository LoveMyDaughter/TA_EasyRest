using TestFramework.PageComponents;

namespace TestFramework.Pages
{
    public class ModeratorPanelRestaurantsPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }

        public AdminPanelPageComponent AdminPanelPageComponent { get; }

        public ModeratorPanelRestaurantsPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            
            // Panel's button "Moderators" is not visible on the current page. We don't use it
            AdminPanelPageComponent = new AdminPanelPageComponent(driver);
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
