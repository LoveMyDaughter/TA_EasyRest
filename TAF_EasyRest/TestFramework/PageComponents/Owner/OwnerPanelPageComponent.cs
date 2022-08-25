
namespace TestFramework.PageComponents
{
    public class OwnerPanelPageComponent
    {
        IWebDriver driver { get; }

        public OwnerPanelPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _manageButton => driver.FindElement(By.XPath("//span[text() = 'Manage']/ancestor::a"));
        private IWebElement _archiveButton => driver.FindElement(By.XPath("//span[text() = 'Archive']/ancestor::li"));

        public OwnerEditRestaurantPage ClickManageButton()
        {
            _manageButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.UrlContains("/edit/info"));
            return new OwnerEditRestaurantPage(driver);
        }

        public OwnerPanelRestaurantsPage ClickArchiveButton()
        {
            _archiveButton.Click();
            return new OwnerPanelRestaurantsPage(driver);
        }
    }
}
