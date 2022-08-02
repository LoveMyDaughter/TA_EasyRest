namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent
    {
        IWebDriver driver;

        public WaitingForConfirmCardPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _acceptButton => driver.FindElement(By.XPath("//button//span[text()='Accept']"));

        //method to check that the order was accepted by checking if the number of orders decreased in the current tab
        public bool AcceptAnyOrder()
        {
            //return list of web elements which represent order cards with status "Waiting for confirm"
            var cardsBeforeAccepting = driver.FindElements(By.XPath("//main/div/div/div/div/div"));

            _acceptButton.Click();

            var cardsAfterAccepting = driver.FindElements(By.XPath("//main/div/div/div/div/div"));

            return cardsBeforeAccepting.Count == cardsAfterAccepting.Count + 1;
        }
    }
}
