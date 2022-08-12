namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent : BasePageComponent
    {
        private IWebElement _card { get; }

        public WaitingForConfirmCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private By _acceptButton => By.XPath(".//button//span[text()='Accept']");

        public WaitingForConfirmCardPageComponent ClickAcceptButton(int timeToWait)
        {           
            WaitUntilElementIsVisible(_acceptButton, _card, timeToWait)
                .Click();
            return this;
        }    
    }
}
