namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class MenuItemDetailsPageComponent
    {
        IWebDriver driver { get; }

        public MenuItemDetailsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
