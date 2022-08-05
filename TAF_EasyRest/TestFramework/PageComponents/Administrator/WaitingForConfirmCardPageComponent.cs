namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent
    {
        private IWebElement card { get; }

        public WaitingForConfirmCardPageComponent(IWebElement card)
        {
            this.card = card;
        }

        private IWebElement _acceptButton => card.FindElement(By.XPath(".//button//span[text()='Accept']"));

        public WaitingForConfirmCardPageComponent ClickAcceptButton()
        {           
            _acceptButton.Click();           
            return this;
        }    
    }
}
