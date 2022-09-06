using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.RestaurantMenuComponents;
using TestFramework.Tools.GetData;

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

        private By _showCartButton => By.XPath("//button[@aria-label='Show cart']");

        public CartPageComponent ClickShowCartButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_showCartButton, timeToWait)
                .Click();
            
            return new CartPageComponent(driver);
        }

        public CartPageComponent AddTheFistDishToTheCart(int timeToWait)
        {
            var addToCartButton = By.XPath("//button[contains(@class,'addButton')][1]");

            driver.WaitUntilElementIsVisible(addToCartButton, timeToWait)
                .Click();

            return new CartPageComponent(driver);
        }
    }
}
