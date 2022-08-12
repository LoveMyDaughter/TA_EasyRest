
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
            Thread.Sleep(1000);
            return new OwnerEditRestaurantPage(driver);
        }

        public OwnerPanelPageComponent ClickArchiveButton()
        {
            _archiveButton.Click();
            return new OwnerPanelPageComponent(driver);
        }
    }
}
