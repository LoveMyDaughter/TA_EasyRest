namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent 
    {
        private IWebElement _card { get; }

        public WaitingForConfirmCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private By _acceptButton => By.XPath(".//button//span[text()='Accept']");

        public WaitingForConfirmCardPageComponent ClickAcceptButton(int timeToWait)
        {
            var driver = _card.GetWebDriverFromWebElement();
            driver.WaitUntilElementIsVisible(_acceptButton, timeToWait)
                .Click();
            return this;
        }    
    }
}
