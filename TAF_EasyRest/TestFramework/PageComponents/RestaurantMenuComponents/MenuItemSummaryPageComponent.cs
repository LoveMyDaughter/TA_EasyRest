namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class MenuItemSummaryPageComponent
    {
        IWebDriver driver { get; }
        private int index;

        public MenuItemSummaryPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _expandButton => driver.FindElement(By.XPath($"(//button[@class='MuiButtonBase-root-106 MuiIconButton-root-1576 MenuItem-expandButton-2489'])[{index}]"));
        private IWebElement _addToCartButton => driver.FindElement(By.XPath($"(//button[@class='MuiButtonBase-root-106 MuiIconButton-root-1576 MenuItem-addButton-2492'])[{index}]"));

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
