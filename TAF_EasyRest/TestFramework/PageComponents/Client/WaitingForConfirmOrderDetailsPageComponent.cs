namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderDetailsPageComponent
    {
        private IWebDriver driver;
        private int index;
        public string number { get; }
        public WaitingForConfirmOrderDetailsPageComponent(IWebDriver driver, int index, string number)
        {
            this.driver = driver;
            this.index = index;
            this.number = number;
        }

        private By _declineButton => By.XPath($"//span[text()='Decline'][{index}]");

        public CurrentOrdersPage ClickDeclineButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_declineButton, timeToWait).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.ElementIsVisible(By.XPath($"//p[text()='{number}']//parent::div")));

            return new CurrentOrdersPage(driver);
        }
    }
}
