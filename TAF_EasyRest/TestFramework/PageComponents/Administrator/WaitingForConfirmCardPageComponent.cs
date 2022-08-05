namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent
    {
        private IWebElement _card { get; }

        public WaitingForConfirmCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private IWebElement _acceptButton => _card.FindElement(By.XPath(".//button//span[text()='Accept']"));

        public WaitingForConfirmCardPageComponent ClickAcceptButton()
        {           
            _acceptButton.Click();           
            return this;
        }    
    }
}
