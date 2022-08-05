
namespace TestFramework.PageComponents.Waiter
{
    public class InProgressCardPageComponent
    {
        private IWebElement _card { get; }

        public InProgressCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private IWebElement _closeOrderButton => _card.FindElement(By.XPath(".//span[text()='Close order']"));

        public InProgressCardPageComponent ClickCloseButton()
        {
            _closeOrderButton.Click();
            return this;
        }
    }
}
