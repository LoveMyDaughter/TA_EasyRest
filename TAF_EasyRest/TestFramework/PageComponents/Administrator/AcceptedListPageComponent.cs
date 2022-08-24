
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedListPageComponent
    {
        private IWebDriver driver { get; }
        
        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'MuiExpansionPanel-root')]"));

        public AcceptedListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AcceptedCardPageComponent ExpandTheFirstOrder(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(d => _orders.Count > 0);

            var card = _orders.ElementAt(0);
            var expandButton = card.FindElement(By.XPath(".//div[contains(@class, 'MuiExpansionPanelSummary-content')]/following-sibling::div"));
            expandButton.Click();

            return new AcceptedCardPageComponent(card);
        }
        
        public int CheckTheNumberOfOrdersInTheCurrentTab(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(d => _orders.Count > 0);

            return _orders.Count;
        }

        public string GetIdOfTheFirstOrder()
        {
            return _orders.ElementAt(0)
                .FindElement(By.XPath(".//p[text() = 'Order id: #']"))
                .Text
                .Remove(0, 11);
        }
    }
}
