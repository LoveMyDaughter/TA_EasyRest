using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;


namespace TestFramework.Pages
{
    public class RestaurantsListPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }

        public RestaurantsListPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }

        private IWebElement _DetailsButton => driver.FindElement(By.XPath("//span[text()='details']"));
        private IWebElement _WatchMenuButton => driver.FindElement(By.XPath("Watch Menu"));

        public RestaurantsListPage ClickDetailsButton()
        {
            _DetailsButton.Click();
            return this;
        }

        public RestaurantsListPage ClickWatchMenuButton()
        {
            _WatchMenuButton.Click();
            return this;
        }
    }
}
