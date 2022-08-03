namespace TestFramework.PageComponents
{
    public class HistoryOrderDetailsPageComponent
    {
        private IWebDriver driver;
        private int index;

        public HistoryOrderDetailsPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        
        private IWebElement _reorderButton => driver.FindElement(By.XPath($"(//div[@class='UserOrders-root-1340']/child::div)[{index}]//button"));

        public HistoryOrderDetailsPageComponent ClickReorderButton()
        {
            _reorderButton.Click();
            return this;
        }
    }
}
