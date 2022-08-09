
namespace TestFramework.PageComponents
{
    public class OwnerEditRestaurantPageComponent
    {
        private IWebDriver driver { get; }

        public OwnerEditRestaurantPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        private IWebElement _updateButton => driver.FindElement(By.XPath("//span[contains(text(),'Update')]/parent::button"));
        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));

        public OwnerEditRestaurantPageComponent ClickUpdateButton()
        {
            _updateButton.Click();
            return new OwnerEditRestaurantPageComponent(driver);
        }
        public OwnerEditRestaurantPageComponent ClickCancelButton()
        {
            _cancelButton.Click();
            return this;
        }
    }
}
