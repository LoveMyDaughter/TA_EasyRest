
namespace TestFramework.PageComponents.Waiter
{
    public class AssignedWaiterCardPageComponent
    {
        private IWebDriver driver { get; }
        private IWebElement card { get; }

        //return number of web elements which represent order cards with status "Assigned waiter" before starting an order
        private int cardsBeforeStarting;

        //return number of web elements which represent order cards with status "Assigned waiter" after starting the order
        private int cardsAfterStarting;

        public AssignedWaiterCardPageComponent(IWebDriver driver, IWebElement card)
        {
            this.driver = driver;
            this.card = card;
        }

        private IWebElement _startButton => card.FindElement(By.XPath(".//span[text()='Start order']"));

        public AssignedWaiterCardPageComponent ClickStartButton()
        {
            cardsBeforeStarting = driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]")).Count;

            _startButton.Click();

            cardsAfterStarting = driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]")).Count;

            return this;
        }

        //method to check that the order was started by checking if the number of orders decreased by one in the current tab
        public bool CheckThatTheCountOfAssignedWaiterOrdersHaveDecreasedByOne()
        {
            return cardsBeforeStarting == cardsAfterStarting + 1;
        }
    }
}
