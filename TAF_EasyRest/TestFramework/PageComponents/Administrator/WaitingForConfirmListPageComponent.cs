
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmListPageComponent : BasePageComponent
    {
        private IWebDriver driver { get; }

        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'MuiExpansionPanel-root')]"));

        public WaitingForConfirmListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WaitingForConfirmCardPageComponent ExpandTheFirstOrder()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d=>_orders.Count>0);

            var card = _orders.ElementAt(0);
            var expandButton = card.FindElement(By.XPath(".//div[contains(@class, 'MuiExpansionPanelSummary-content')]/following-sibling::div"));
            expandButton.Click();
            return new WaitingForConfirmCardPageComponent(card);
        }

        public int CheckTheNumberOfOrdersInTheCurrentTab()
        {
            return _orders.Count;
        }
    }
}
