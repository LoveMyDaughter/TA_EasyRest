
namespace TestFramework.PageComponents.Waiter
{
    public class InProgressCardPageComponent
    {
        private IWebElement card { get; }

        public InProgressCardPageComponent(IWebElement card)
        {
            this.card = card;
        }

        private IWebElement _closeOrderButton => card.FindElement(By.XPath(".//span[text()='Close order']"));

        public InProgressCardPageComponent ClickCloseButton()
        {
            _closeOrderButton.Click();
            return this;
        }
    }
}
