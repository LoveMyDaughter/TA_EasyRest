
namespace TestFramework.PageComponents.Waiter
{
    public class AssignedWaiterListPageComponent
    {
        private IWebDriver driver { get; }

        private IReadOnlyCollection<IWebElement> _orders => driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]"));

        public AssignedWaiterListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AssignedWaiterCardPageComponent ExpandTheFirstOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("//main//span[contains( @class, 'MuiIconButton-label')]"));
            expandButton.Click();

            return new AssignedWaiterCardPageComponent(card);
        }

        public int CheckTheNumberOfOrdersInTheCurrentTab()
        {
            return _orders.Count;
        }
    }
}
