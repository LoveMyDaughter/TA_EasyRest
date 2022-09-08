namespace TestFramework.PageComponents
{
    public class OrderPageComponent
    {
        private IWebDriver driver;
        private int index;
        private string number => _orderField.FindElement(By.XPath($"//div[@class='MuiGrid-item-120 MuiGrid-grid-xs-1-148'][1]")).Text;

        public OrderPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _orderField => driver.FindElement(By.XPath($"//div[contains(@class,'MuiExpansionPanel-rounded')][{index}]"));

        public HistoryOrderDetailsPageComponent ExpandOrderDetails()
        {
            _orderField.Click();
            return new HistoryOrderDetailsPageComponent(driver, index, number);
        }
    }
}
