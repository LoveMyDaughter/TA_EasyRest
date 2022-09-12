
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedCardPageComponent
    {
        private IWebElement _card { get; }

        public AcceptedCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private IWebElement _selectWaiterRadioButton => _card.FindElement(By.XPath(".//input[@name = 'waiters']/.."));
        private By _assignButton = By.XPath("(.//span[text()='Assign'])[1]");

        public AcceptedCardPageComponent SelectTheFirstWaiter(int timeToWait)
        {
            var driver = _card.GetWebDriverFromWebElement();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementToBeClickable(_selectWaiterRadioButton))
                .Click();
            return this;
        }

        public AcceptedCardPageComponent ClickAssignButton(int timeToWait)
        {          
            _card.FindElement(_assignButton).Click();
            
            var driver = _card.GetWebDriverFromWebElement();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(_assignButton));
            
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
            return this;
        }
    }
}
