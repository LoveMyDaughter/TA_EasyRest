
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedCardPageComponent
    {
        IWebDriver driver { get; }

        public AcceptedCardPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _selectWaiterRadioButton => driver.FindElement(By.XPath("(//input)[1]"));
        private IWebElement _assignButton => driver.FindElement(By.XPath("(//span[text()='Assign'])[1]"));

        public AcceptedCardPageComponent SelectAnyWaiter()
        {
            _selectWaiterRadioButton.Click();
            return this;
        }

        //method to check that the order was assigned by checking if the number of orders decreased in the current tab
        public bool ClickAssignButton()
        {
            //return list of web elements which represent order cards with status "Accepted" 
            var cardsBeforeAssigning = driver.FindElements(By.XPath("//main/div/div/div/div/div"));

            _assignButton.Click();

            var cardsAfterAssigning = driver.FindElements(By.XPath("//main/div/div/div/div/div"));

            return cardsBeforeAssigning.Count == cardsAfterAssigning.Count + 1;
        }
    }
}
