using TestFramework.PageComponents;
namespace TestFramework.Pages
{
    public class OrderConfirmationPageComponent
    {
        public List<OrderSummaryDetailsPageComponent> _summaryDetails { get; private set; }
        private IWebDriver driver;
        public OrderConfirmationPageComponent(IWebDriver driver)
        {
            this.driver = driver;
            FillOdersList();
        }

        #region Elements
        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']//parent::button"));
        private IWebElement _submitButton => driver.FindElement(By.XPath("//span[text()='Submit']//parent::button"));
        #endregion

        #region Methods
        private int СountOrders()
        {
            IReadOnlyCollection<IWebElement> _summaryDetails = driver.FindElements(By.XPath("//td[contains(@class,'MuiTableCell-body')and contains(@class,'MuiTableCell-paddingCheckbox')]//parent::tr"));
            return _summaryDetails.Count();
        }

        private void FillOdersList()
        {
            _summaryDetails = new List<OrderSummaryDetailsPageComponent>(СountOrders());
            for (int i = 0; i < _summaryDetails.Count; i++)
            {
                _summaryDetails.Add(new OrderSummaryDetailsPageComponent(driver, (i + 1)));
            }
        }

        public RestaurantMenuPage ClickCancelButton()
        {
            _cancelButton.Click();
            return new RestaurantMenuPage(driver);
        }

        public RestaurantMenuPage ClickSubmitButton()
        {
            _submitButton.Click();
            return new RestaurantMenuPage(driver);
        }
        #endregion
    }
}