using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.RestaurantMenuComponents;

namespace TestFramework.Pages
{
    public class RestaurantMenuPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        public IReadOnlyCollection <IWebElement> MenuItemSummaryPageComponents;
        //private IWebElement ContainerForMenuItems => driver.FindElement(By.XPath("//div[@class='MuiGrid-item-2347 MuiGrid-grid-xs-12-2386 MuiGrid-grid-md-8-2410']"));

        public RestaurantMenuPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            
            MenuItemSummaryPageComponents = driver.FindElements(By.XPath("//div[@class='MenuItem-root-2484']"));
            
            foreach (var menuItem in MenuItemSummaryPageComponents)
            {
                new MenuItemSummaryPageComponent(driver);
            }
        }

        private IWebElement _showCartButton => driver.FindElement(By.XPath("//button[@aria-label='Show cart']"));

        public CartPageComponent ClickShowCartButton()
        {
            _showCartButton.Click();
            return new CartPageComponent(driver);
        }

        


    }
}
