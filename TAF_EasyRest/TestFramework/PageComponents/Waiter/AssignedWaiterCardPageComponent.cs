
namespace TestFramework.PageComponents.Waiter
{
    public class AssignedWaiterCardPageComponent
    {
        private IWebElement card { get; }

        public AssignedWaiterCardPageComponent(IWebElement card)
        {
            this.card = card;
        }

        private IWebElement _startButton => card.FindElement(By.XPath(".//span[text()='Start order']"));

        public AssignedWaiterCardPageComponent ClickStartButton()
        {
            _startButton.Click();
            return this;
        }
    }
}
