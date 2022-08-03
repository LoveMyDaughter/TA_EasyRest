namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent
    {
        private IWebDriver driver { get; }

        //return number of web elements which represent order cards with status "Waiting for confirm" before accepting an order
        private int cardsBeforeAccepting;

        //return number of web elements which represent order cards with status "Waiting for confirm" after accepting the order
        private int cardsAfterAccepting;

        public WaitingForConfirmCardPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _acceptButton => driver.FindElement(By.XPath("//button//span[text()='Accept']"));

        public WaitingForConfirmCardPageComponent ClickAcceptButton()
        {
            cardsBeforeAccepting = driver.FindElements(By.XPath("//main/div/div/div/div/div")).Count;
            
            _acceptButton.Click();
            
            cardsAfterAccepting = driver.FindElements(By.XPath("//main/div/div/div/div/div")).Count;
           
            return this;
        }
        
        //method to check that the order was accepted by checking if the number of orders decreased by one in the current tab
        public bool CheckThatCountOfWaitingForConfirmOrdersHaveDecreasedByOne()
        {
            return cardsBeforeAccepting == cardsAfterAccepting + 1;
        }
    }
}
