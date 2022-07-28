namespace TestFramework.PageComponents
{
    public class OrderPageComponent
    {
        private IWebDriver driver;
        private int number;

        public OrderPageComponent(IWebDriver driver, int number)
        {
            this.driver = driver;
            this.number = number;
        }

        private IWebElement _orderField => driver.FindElement(By.XPath($"((//div[@class='MuiPaper-root-10 MuiPaper-elevation1-13 MuiPaper-rounded-11 MuiExpansionPanel-root-404 MuiExpansionPanel-rounded-405'])[{number}]"));
    
        public HistoryOrderDetailsPageComponent ExpandOrderDetails()
        {
            _orderField.Click();
            return new HistoryOrderDetailsPageComponent(driver);
        }
    }
}
