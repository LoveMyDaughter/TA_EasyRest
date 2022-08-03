namespace TestFramework.PageComponents.RestaurantMenuComponents
{
    public class OrderConfirmationWindowPageComponent
    {
        IWebDriver driver { get; }

        public OrderConfirmationWindowPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _cancelButton => driver.FindElement(By.XPath("//button/span[text()='Cancel']"));
        private IWebElement _submitlButton => driver.FindElement(By.XPath("//button/span[text()='Submit']"));

        public RestaurantMenuPage ClickCancelButton()
        {
            _cancelButton.Click();
            return new RestaurantMenuPage(driver);
        }

        public RestaurantMenuPage ClickSubmitlButton()
        {
            _submitlButton.Click();
            return new RestaurantMenuPage(driver);
        }
    }
}
