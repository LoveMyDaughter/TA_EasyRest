namespace TestFramework.PageComponents
{
    public class HistoryOrderDetailsPageComponent
    {
        private IWebDriver driver;
        private int index;
        private string number;

        public HistoryOrderDetailsPageComponent(IWebDriver driver, int index, string number)
        {
            this.driver = driver;
            this.index = index;
            this.number = number;
        }


        private By _reorderButton => By.XPath($"//span[text()='Reorder']//ancestor::button[{index}]");

        public OrderConfirmationPageComponent ClickReorderButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_reorderButton, timeToWait).Click();
            //new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath($"//p[text()='{number}']//parent::div"), number));
            //Thread.Sleep(timeToWait);

            return new OrderConfirmationPageComponent(driver);
        }
    }
}
