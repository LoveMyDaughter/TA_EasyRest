namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderPageComponent
    {
        private IWebDriver driver;

        public WaitingForConfirmOrderPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _declineButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-2528']/child::div)[1]//button"));

        public WaitingForConfirmOrderPageComponent ClickDeclineButton()
        {
            _declineButton.Click();
            return this;
        }
    }
}
