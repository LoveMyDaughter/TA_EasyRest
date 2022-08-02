
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedListPageComponent
    {
        IWebDriver driver { get; }
        
        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'MuiTypography-root')]//div[contains(@class, ' MuiExpansionPanelSummary-root-450')]"));

        public AcceptedListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AcceptedCardPageComponent ExpandAnyOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("./div[@role='button']"));
            expandButton.Click();

            return new AcceptedCardPageComponent(driver);
        }
    }
}
