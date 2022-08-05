
namespace TestFramework.PageComponents.Waiter
{
    public class InProgressCardPageComponent
    {
        private IWebElement _card { get; }

        public InProgressCardPageComponent(IWebElement _card)
        {
            this._card = _card;
        }

        private IWebElement _closeOrderButton => _card.FindElement(By.XPath(".//span[text()='Close order']"));

        public InProgressCardPageComponent ClickCloseButton()
        {
            _closeOrderButton.Click();
            return this;
        }
    }
}
