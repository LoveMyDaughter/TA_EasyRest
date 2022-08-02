
namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderCardPageComponent
    {
        IWebDriver driver;

        public WaitingForConfirmOrderCardPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _acceptButton => driver.FindElement(By.XPath("//button//span[text()='Accept']"));

        public bool AcceptAnyOrder()
        {
            var cardsBeforeAccepting = driver.FindElements(By.XPath(("//main/div/div/div/div/div")));
            
            _acceptButton.Click();
            
            var cardsAfterAccepting = driver.FindElements(By.XPath(("//main/div/div/div/div/div")));

            return cardsBeforeAccepting.Count == cardsAfterAccepting.Count + 1;
        }
    }
}
