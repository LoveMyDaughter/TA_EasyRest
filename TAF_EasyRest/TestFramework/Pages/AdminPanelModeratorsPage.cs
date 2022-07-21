namespace TestFramework.Pages
{
    public class AdminPanelModeratorsPage : BasePage
    {


        #region Elements

        private IWebElement _addModeratorButton => driver.FindElement(By.XPath("//*[@id = 'root']/div/main/a"));
        private IWebElement _usersButton => driver.FindElement(By.XPath("//span[text() = 'Users']/ancestor::a"));
        private IWebElement _ownersButton => driver.FindElement(By.XPath("//span[text() = 'Owners']/ancestor::a"));
        private IWebElement _moderatorsButton => driver.FindElement(By.XPath("//span[text() = 'Moderators']/ancestor::a"));
        private IWebElement _restaurantsButton => driver.FindElement(By.XPath("//span[text() = 'Restaurants']/ancestor::a"));
        // Corresponding entry button. It's better to find 1-st row instead of certain user name
        private IWebElement _padlockButton => driver.FindElement(By.XPath("//th[text()='Peter Moderator']/following-sibling::td/button"));
        private IWebElement _statusRecord => driver.FindElement(By.XPath("//th[text()='Peter Moderator']/following-sibling::td/p"));
        private IWebElement _padlockButtonForCertainUser (string username) => driver.FindElement(By.XPath($"//th[text()='{username}']/following-sibling::td/button"));
        
        #endregion


        public AdminPanelModeratorsPage(IWebDriver driver) : base(driver) { }



        #region Methods
        public AdminPanelModeratorsPage GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(baseUrl + url);
            return this;
        }


        public AdminPanelModeratorsPage ClickModeratorsButton()
        {
            _moderatorsButton.Click();
            return this;
        }

        public AdminPanelModeratorsPage ClickPadlockButton()
        {
            _padlockButton.Click();
            return this;
        }

        public AdminPanelModeratorsPage ClickAddModeratorButton()
        {
            _addModeratorButton.Click();
            return this;
        }

        public string StatusRecordGetText()
        {
            return _statusRecord.Text;
        }

        #endregion

    }
}
