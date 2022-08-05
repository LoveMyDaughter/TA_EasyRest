
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedCardPageComponent
    {
        private IWebElement _card { get; }

        public AcceptedCardPageComponent(IWebElement _card)
        {
            this._card = _card;
        }

        private IWebElement _selectWaiterRadioButton => _card.FindElement(By.XPath("(.//input)[1]"));
        private IWebElement _assignButton => _card.FindElement(By.XPath("(.//span[text()='Assign'])[1]"));

        public AcceptedCardPageComponent SelectTheFirstWaiter()
        {
            _selectWaiterRadioButton.Click();
            return this;
        }

        public AcceptedCardPageComponent ClickAssignButton()
        {            
            _assignButton.Click();           
            return this;
        }
    }
}
