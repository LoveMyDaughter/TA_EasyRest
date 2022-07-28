namespace TestFramework.PageComponents
{
    public class OrderPageComponent
    {
        private IWebDriver driver;

        public OrderPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _reorderButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-1340']/child::div)[1]//button"));

        public OrderPageComponent ClickReorderButton()
        {
            _reorderButton.Click();
            return this;
        }
    }
}
