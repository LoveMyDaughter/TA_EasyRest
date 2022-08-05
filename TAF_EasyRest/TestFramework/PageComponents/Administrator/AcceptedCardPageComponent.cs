
namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class AcceptedCardPageComponent
    {
        private IWebElement card { get; }

        public AcceptedCardPageComponent(IWebElement card)
        {
            this.card = card;
        }

        private IWebElement _selectWaiterRadioButton => card.FindElement(By.XPath("(.//input)[1]"));
        private IWebElement _assignButton => card.FindElement(By.XPath("(.//span[text()='Assign'])[1]"));

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
