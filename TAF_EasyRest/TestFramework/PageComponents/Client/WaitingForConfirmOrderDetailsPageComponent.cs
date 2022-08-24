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

        private By _declineButton => By.XPath($"//span[text()='Decline'][{index}]");

        public CurrentOrdersPage ClickDeclineButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_declineButton, timeToWait).Click();

            return new CurrentOrdersPage(driver);
        }
    }
}
