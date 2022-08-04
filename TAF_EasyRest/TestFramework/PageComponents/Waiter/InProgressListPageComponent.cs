
namespace TestFramework.PageComponents.Waiter
{
    public class InProgressListPageComponent
    {
        private IWebDriver driver { get; }

        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]"));

        public InProgressListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public InProgressCardPageComponent ExpandTheFirstOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("//main//span[contains( @class, 'MuiIconButton-label')]"));
            expandButton.Click();

            return new InProgressCardPageComponent(driver, card);
        }
    }
}
