
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmListPageComponent
    {
        IWebDriver driver;

        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'MuiTypography-root')]//div[contains(@class, ' MuiExpansionPanelSummary-root-450')]"));

        public WaitingForConfirmListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WaitingForConfirmCardPageComponent ExpandAnyOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("./div[@role='button']"));
            expandButton.Click();

            return new WaitingForConfirmCardPageComponent(driver);
        }
    }
}
