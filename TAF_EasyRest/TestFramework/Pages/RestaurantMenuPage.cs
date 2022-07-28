using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.RestaurantMenuComponents;

namespace TestFramework.Pages
{
    public class RestaurantMenuPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        private IReadOnlyCollection <IWebElement> MenuItemSummaryWebElements { get; }
        public List <MenuItemSummaryPageComponent> MenuItemSummaryPageComponentsList { get; }

        public RestaurantMenuPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            
            MenuItemSummaryWebElements = driver.FindElements(By.XPath("//div[@class='MenuItem-root-2484']"));

            MenuItemSummaryPageComponentsList = new List<MenuItemSummaryPageComponent>();

            for (int i = 0; i < MenuItemSummaryWebElements.Count; i++)
            {
                MenuItemSummaryPageComponentsList.Add(new MenuItemSummaryPageComponent(driver, i+1));
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
