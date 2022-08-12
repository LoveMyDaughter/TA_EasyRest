namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderDetailsPageComponent
    {
        private IWebDriver driver;
        private int index;
        public WaitingForConfirmOrderDetailsPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _declineButton => driver.FindElement(By.XPath($"//span[text()='Decline'][{index}]"));

        public WaitingForConfirmOrderDetailsPageComponent ClickDeclineButton()
        {
            _declineButton.Click();
            return this;
        }
    }
}
