namespace TestFramework.PageComponents
{
    public class AdminPanelPageComponent : BasePage
    {
        public AdminPanelPageComponent(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement _usersButton => driver.FindElement(By.XPath("//span[text() = 'Users']/ancestor::a"));
        private IWebElement _ownersButton => driver.FindElement(By.XPath("//span[text() = 'Owners']/ancestor::a"));
        private IWebElement _restaurantsButton => driver.FindElement(By.XPath("//span[text() = 'Restaurants']/ancestor::a"));

        #endregion


        #region Methods

        public AdminPanelPageComponent ClickUsersButton()
        {
            _usersButton.Click();
            return this;
        }
        public AdminPanelPageComponent ClickOwnersButton()
        {
            _ownersButton.Click();
            return this;
        }

         public AdminPanelPageComponent ClickRestaurantsButton()
        {
            _restaurantsButton.Click();
            return this;
        }


        #endregion

    }
}
