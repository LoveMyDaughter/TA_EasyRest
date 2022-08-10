namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderPageComponent
    {
        private IWebDriver driver;
        private int index;

        public WaitingForConfirmOrderPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _orderField => driver.FindElement(By.XPath($"//div[contains(@class,'MuiExpansionPanel-rounded')][{index}]"));

        public WaitingForConfirmOrderDetailsPageComponent ExpandOrderField()
        {
            _orderField.Click();
            Thread.Sleep(1000);
            return new WaitingForConfirmOrderDetailsPageComponent(driver, index);
        }
    }
}
