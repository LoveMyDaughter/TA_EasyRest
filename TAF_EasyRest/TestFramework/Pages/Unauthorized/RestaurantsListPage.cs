using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class RestaurantsListPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        private static string _pageUrl => GetUrls.getUrl("RestaurantsListPage").Url;

        public RestaurantsListPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }

        private By _DetailsButton => By.XPath("//span[text()='details']");
        private By _WatchMenuButton => By.XPath("//span[text()='Watch Menu']//parent::a//parent::div");

        public RestaurantsListPage ClickDetailsButton(int timeToWait)
        {

            driver.WaitUntilElementIsVisible(_DetailsButton, timeToWait)
                .Click(); 
            
            return this;
        }

        public RestaurantMenuPage ClickWatchMenuButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_WatchMenuButton, timeToWait)
                .Click();

            return new RestaurantMenuPage(driver);
        }

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }
    }
}
