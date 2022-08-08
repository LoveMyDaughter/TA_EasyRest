using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.RestaurantMenuComponents;

namespace TestFramework.Pages
{
    public class RestaurantMenuPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        private IReadOnlyCollection<IWebElement> _menuItemSummaryCards => driver.FindElements(By.XPath("//div[contains(@class,'MenuItem-root')]"));


        public RestaurantMenuPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);          
        }

        private IWebElement _showCartButton => driver.FindElement(By.XPath("//button[@aria-label='Show cart']"));

        public CartPageComponent ClickShowCartButton()
        {
            _showCartButton.Click();
            return new CartPageComponent(driver);
        }

        public RestaurantMenuPage AddTheFistDishToTheCart()
        {
            var menuItem = _menuItemSummaryCards.ElementAt(0);
            
            var addToCartButton = menuItem.FindElement(By.XPath(".//button[contains(@class,'addButton')]"));

            addToCartButton.Click();

            return this;
        }
    }
}
