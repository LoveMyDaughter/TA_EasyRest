namespace TestFramework.PageComponents.Owner
{
    public class RestaurantItemPageComponent
    {
        private IWebElement _restaurantElement;
        private IWebDriver _webDriver;
        public RestaurantItemPageComponent(IWebElement element, IWebDriver webDriver)
        {
            _restaurantElement = element;
            _webDriver = webDriver;
        }

        private IWebElement _threeDotButton => _restaurantElement.FindElement(By.XPath("//button[@aria-label='More']"));

        public OwnerPanelPageComponent ClickThreeDotButton()
        {
            _threeDotButton.Click();
            return new OwnerPanelPageComponent(_webDriver);
        }
    }
}
