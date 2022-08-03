
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedListPageComponent
    {
        private IWebDriver driver { get; }
        
        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'AdministratorPanel')]/div/div/div/div"));

        public AcceptedListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AcceptedCardPageComponent ExpandTheFirstOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("./div[@role='button']"));
            expandButton.Click();

            return new AcceptedCardPageComponent(driver);
        }
    }
}
