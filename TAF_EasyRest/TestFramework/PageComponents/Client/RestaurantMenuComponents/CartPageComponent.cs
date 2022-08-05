namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class CartPageComponent
    {
        private IWebDriver driver { get; }

        public CartPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _submitButton => driver.FindElement(By.XPath("//button/span[text()='Submit order']"));

        public OrderConfirmationWindowPageComponent ClickSubmitButton()
        {
            _submitButton.Click();
            return new OrderConfirmationWindowPageComponent(driver);
        }
    }
}
