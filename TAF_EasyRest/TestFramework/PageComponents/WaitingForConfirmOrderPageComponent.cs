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

        private IWebElement _orderField => driver.FindElement(By.XPath($"(//div[@class='MuiButtonBase-root-106 MuiExpansionPanelSummary-root-981'])[{index}]"));

        public WaitingForConfirmOrderDetailsPageComponent ExpandOrderField()
        {
            _orderField.Click();
            return new WaitingForConfirmOrderDetailsPageComponent(driver);
        }
    }
}
