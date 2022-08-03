
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

        public OwnerEditRestaurantPage ClickSignInButton()
        {
            _manageButton.Click();
            return new OwnerEditRestaurantPage(driver);
        }

        public OwnerPanelRestaurantsPage ClickSignUpButton()
        {
            _archiveButton.Click();
            return new OwnerPanelRestaurantsPage(driver);
        }
    }
}
