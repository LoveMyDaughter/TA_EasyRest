namespace TestFramework.PageComponents
{
    public class OrderPageComponent
    {
        private IWebDriver driver;
        private int index;

        public OrderPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _orderField => driver.FindElement(By.XPath($"((//div[@class='MuiPaper-root-10 MuiPaper-elevation1-13 MuiPaper-rounded-11 MuiExpansionPanel-root-404 MuiExpansionPanel-rounded-405'])[{index}]"));
    
        public HistoryOrderDetailsPageComponent ExpandOrderDetails()
        {
            _orderField.Click();
            return new HistoryOrderDetailsPageComponent(driver, index);
        }
    }
}
