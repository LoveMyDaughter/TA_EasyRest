namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class MenuItemSummaryPageComponent
    {
        IWebDriver driver { get; }

        public MenuItemSummaryPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _expandButton => driver.FindElement(By.XPath("//button[@class='MuiButtonBase - root - 106 MuiIconButton - root - 1576 MenuItem - expandButton - 1988']"));
        private IWebElement _addToCartButton => driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root-106 MuiIconButton-root-1576 MenuItem-addButton-1991']"));

        public MenuItemDetailsPageComponent ClickExpandButton()
        {
            _expandButton.Click();
            return new MenuItemDetailsPageComponent(driver);
        }

        public RestaurantMenuPage ClickAddButton()
        {
            _addToCartButton.Click();
            return new RestaurantMenuPage(driver);
        }
    }
}
