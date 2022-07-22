namespace TestFramework.Pages
{
    public class AdminPanelModeratorsPageComponent : BasePage
    {
        public AdminPanelModeratorsPageComponent(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement _usersButton => driver.FindElement(By.XPath("//span[text() = 'Users']/ancestor::a"));
        private IWebElement _ownersButton => driver.FindElement(By.XPath("//span[text() = 'Owners']/ancestor::a"));
        private IWebElement _moderatorsButton => driver.FindElement(By.XPath("//span[text() = 'Moderators']/ancestor::a"));
        private IWebElement _restaurantsButton => driver.FindElement(By.XPath("//span[text() = 'Restaurants']/ancestor::a"));

        #endregion


        #region Methods

        public AdminPanelModeratorsPageComponent ClickUsersButton()
        {
            _usersButton.Click();
            return this;
        }
        public AdminPanelModeratorsPageComponent ClickOwnersButton()
        {
            _ownersButton.Click();
            return this;
        }
        public AdminPanelModeratorsPageComponent ClickModeratorsButton()
        {
            _moderatorsButton.Click();
            return this;
        }
         public AdminPanelModeratorsPageComponent ClickRestaurantsButton()
        {
            _restaurantsButton.Click();
            return this;
        }


        #endregion

    }
}
