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

        private IWebElement _threeDotButton => _restaurantElement.FindElement(By.XPath(".//button[@aria-label='More']"));
        private IWebElement _name => _restaurantElement.FindElement(By.TagName("h2"));
        public string Name => _name.Text;
        public OwnerPanelPageComponent ClickThreeDotButton(int timeToWait)
        {
            _threeDotButton.Click();
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text() = 'Manage']/ancestor::a")));
            return new OwnerPanelPageComponent(_webDriver);
        }
    }
}
