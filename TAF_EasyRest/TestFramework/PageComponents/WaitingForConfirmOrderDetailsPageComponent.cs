namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderDetailsPageComponent
    {
        private IWebDriver driver;

        public WaitingForConfirmOrderDetailsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _declineButton => driver.FindElement(By.XPath("(//div[@class='UserOrders-root-2528']/child::div)[1]//button"));

        public WaitingForConfirmOrderDetailsPageComponent ClickDeclineButton()
        {
            _declineButton.Click();
            return this;
        }
    }
}
