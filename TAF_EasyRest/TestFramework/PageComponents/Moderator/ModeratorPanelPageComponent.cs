using TestFramework.Pages.Moderator;

namespace TestFramework.PageComponents.Moderator
{
    public class ModeratorPanelPageComponent
    {
        private IWebDriver driver { get; }

        public ModeratorPanelPageComponent (IWebDriver driver)
        {
            this.driver = driver;
        }


        #region Elements

        private IWebElement _restaurantsButton => driver.FindElement(By.XPath("//span[text() = 'Restaurants']"));
        private IWebElement _usersButton => driver.FindElement(By.XPath("//span[text() = 'Users']"));
        private IWebElement _ownersButton => driver.FindElement(By.XPath("//span[text() = 'Owners']"));

        #endregion


        #region Methods

        public ModeratorPanelRestaurantsPage ClickRestaurantsButton()
        {
            _restaurantsButton.Click();
            return new ModeratorPanelRestaurantsPage(driver);
        }

        public ModeratorPanelUsersPage ClickUsersButton()
        {
            _usersButton.Click();
            return new ModeratorPanelUsersPage(driver);
        }

        public ModeratorPanelOwnersPage ClickOwnersButton()
        {
            _ownersButton.Click();
            return new ModeratorPanelOwnersPage(driver);
        }

        #endregion

    }
}
