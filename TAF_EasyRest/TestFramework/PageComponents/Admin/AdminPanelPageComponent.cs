namespace TestFramework.PageComponents
{
    public class AdminPanelPageComponent : BasePage
    {
        public AdminPanelPageComponent(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement _usersButton => driver.FindElement(By.XPath("//span[text() = 'Users']/ancestor::a"));
        private IWebElement _ownersButton => driver.FindElement(By.XPath("//span[text() = 'Owners']/ancestor::a"));
        private IWebElement _moderatorsButton => driver.FindElement(By.XPath("//span[text() = 'Moderators']/ancestor::a"));
        private IWebElement _restaurantsButton => driver.FindElement(By.XPath("//span[text() = 'Restaurants']/ancestor::a"));

        #endregion


        #region Methods

        public AdminPanelModeratorsPage ClickModeratorsButton()
        {
            _moderatorsButton.Click();
            return new AdminPanelModeratorsPage(driver);
        }

        #endregion

    }
}
