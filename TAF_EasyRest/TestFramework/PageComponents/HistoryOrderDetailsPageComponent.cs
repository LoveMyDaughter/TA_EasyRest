namespace TestFramework.PageComponents
{
    public class HistoryOrderDetailsPageComponent
    {
        private IWebDriver driver;

        public HistoryOrderDetailsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        private IWebElement _reorderButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-1340']/child::div)[1]//button"));

        public HistoryOrderDetailsPageComponent ClickReorderButton()
        {
            _reorderButton.Click();
            return this;
        }
    }
}
