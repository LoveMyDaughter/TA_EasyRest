namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class NavigationMenuPageComponent 
    {
        IWebDriver driver { get; }

        public NavigationMenuPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _homeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement _restaurantsList => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));

        public HomePageNonAuthorizedUserPage ClickHomeButton()
        {
            _homeButton.Click();
            return new HomePageNonAuthorizedUserPage(driver);
        }

        public RestaurantsListPage ClickRestaurantsListButton()
        {
            _restaurantsList.Click();
            return new RestaurantsListPage(driver);
        }
    }
}
