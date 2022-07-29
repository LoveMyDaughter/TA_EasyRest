
namespace TestFramework.PageComponents
{
    public class UnapprovedRestaurantPageComponent
    {
        private IWebDriver driver;

        public UnapprovedRestaurantPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _approveButton => driver.FindElement(By.XPath("//span[text() = 'Approve']/parent::button)]"));
        private IWebElement _disapproveButton => driver.FindElement(By.XPath("//span[text() = 'Approve']/parent::button)]"));


        public UnapprovedRestaurantPageComponent ClickApproveButton()
        {
            _approveButton.Click();
            // Refill list of restaurants
            return this;
        }
        
        public UnapprovedRestaurantPageComponent ClickDisapproveButton()
        {
            _disapproveButton.Click();
            // Refill list of restaurants
            return this;
        }
    }
}
