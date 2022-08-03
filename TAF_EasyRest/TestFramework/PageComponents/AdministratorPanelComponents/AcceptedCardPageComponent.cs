
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedCardPageComponent
    {
        private IWebDriver driver { get; }

        //return number of web elements which represent order cards with status "Accepted" before assigning an order to a waiter
        private int cardsBeforeAssigning;

        //return number of web elements which represent order cards with status "Accepted" after assigning the order to a waiter
        private int cardsAfterAssigning;

        public AcceptedCardPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _selectWaiterRadioButton => driver.FindElement(By.XPath("(//input)[1]"));
        private IWebElement _assignButton => driver.FindElement(By.XPath("(//span[text()='Assign'])[1]"));

        public AcceptedCardPageComponent SelectTheFirstWaiter()
        {
            _selectWaiterRadioButton.Click();
            return this;
        }

        public AcceptedCardPageComponent ClickAssignButton()
        {
            cardsBeforeAssigning = driver.FindElements(By.XPath("//main/div/div/div/div/div")).Count;
            
            _assignButton.Click();

            cardsAfterAssigning = driver.FindElements(By.XPath("//main/div/div/div/div/div")).Count;
            
            return this;
        }

        //method to check that the order was assigned by checking if the number of orders decreased in the current tab
        public bool CheckThatCountOfAcceptedOrdersHaveDecreasedByOne()
        {
            return cardsBeforeAssigning == cardsAfterAssigning + 1;
        }
    }
}
