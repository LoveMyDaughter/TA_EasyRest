namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class NavigationMenuPageComponent : BasePage
    {
        public NavigationMenuPageComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, timeout);
        }

        protected static TimeSpan timeout = TimeSpan.FromSeconds(3);
        protected static WebDriverWait wait;

        private IWebElement _HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement _RestaurantsList => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));

        public HomePage ClickHomeButton()
        {
            _HomeButton.Click();
            return new HomePage(driver);
        }

        public RestaurantsListPage ClickRestaurantsListButton()
        {
            _RestaurantsList.Click();
            return new RestaurantsList(driver);
        }
    }
}
