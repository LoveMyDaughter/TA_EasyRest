
namespace TestFramework.PageComponents.Waiter
{
    public class InProgressCardPageComponent
    {
        private IWebDriver driver { get; }
        private IWebElement card { get; }

        //return number of web elements which represent order cards with status "In progress" before closing an order
        private int cardsBeforeClosing;

        //return number of web elements which represent order cards with status "In progress" after closing the order
        private int cardsAfterClosing;

        public InProgressCardPageComponent(IWebDriver driver, IWebElement card)
        {
            this.driver = driver;
            this.card = card;
        }

        private IWebElement _closeOrderButton => card.FindElement(By.XPath(".//span[text()='Close order']"));

        public InProgressCardPageComponent ClickCloseButton()
        {
            cardsBeforeClosing = driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]")).Count;

            _closeOrderButton.Click();

            cardsAfterClosing = driver.FindElements(By.XPath("//div[contains(@class, 'Order-card')]")).Count;

            return this;
        }

        //method to check that the order was closed by checking if the number of orders decreased by one in the current tab
        public bool CheckThatTheCountOfAssignedWaiterOrdersHaveDecreasedByOne()
        {
            return cardsBeforeClosing == cardsAfterClosing + 1;
        }
    }
}
