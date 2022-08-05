
namespace TestFramework.PageComponents.Waiter
{
    public class AssignedWaiterCardPageComponent
    {
        private IWebElement _card { get; }

        public AssignedWaiterCardPageComponent(IWebElement _card)
        {
            this._card = _card;
        }

        private IWebElement _startButton => _card.FindElement(By.XPath(".//span[text()='Start order']"));

        public AssignedWaiterCardPageComponent ClickStartButton()
        {
            _startButton.Click();
            return this;
        }
    }
}
