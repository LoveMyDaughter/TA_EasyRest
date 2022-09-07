namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class CartPageComponent
    {
        private IWebDriver driver { get; }

        public CartPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By _submitButton => By.XPath("//button/span[text()='Submit order']");

        public OrderConfirmationPageComponent ClickSubmitButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_submitButton, timeToWait)
                .Click();
            
            return new OrderConfirmationPageComponent(driver);
        }
    }
}
