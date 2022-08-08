namespace TestFramework.PageComponents
{
    public class OrderSummaryDetailsPageComponent
    {
        private IWebDriver driver;
        private int index;

        public OrderSummaryDetailsPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        #region Elements
        private IWebElement _currentElement => driver.FindElement(By.XPath($"(//td[contains(@class,'MuiTableCell-body')and contains(@class,'MuiTableCell-paddingCheckbox')]//parent::tr)[{index}]"));
        private IWebElement _removeButton => _currentElement.FindElement(By.XPath(".//button[@aria-label='Remove item']"));
        private IWebElement _quantityField => _currentElement.FindElement(By.XPath(".//input[@type='number']"));
        #endregion

        #region Methods
        public OrderConfirmationPageComponent ClickRemoveButton()
        {
            _removeButton.Click();
            return new OrderConfirmationPageComponent(driver);
        }

        public OrderConfirmationPageComponent ChangeQuantity(string keys)
        {
            _quantityField.Click();
            _quantityField.SendKeys(keys);
            return new OrderConfirmationPageComponent(driver);
        }
        #endregion
    }
}