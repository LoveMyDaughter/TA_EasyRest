
namespace TestFramework.PageComponents.Waiter
{
    public class AssignedWaiterCardPageComponent
    {
        private IWebElement _card { get; }

        public AssignedWaiterCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private IWebElement _startButton => _card.FindElement(By.XPath(".//span[text()='Start order']"));

        public AssignedWaiterCardPageComponent ClickStartButton()
        {
            _startButton.Click();
            return this;
        }
    }
}
