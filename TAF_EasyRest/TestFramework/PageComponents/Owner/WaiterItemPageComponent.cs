namespace TestFramework.PageComponents.Owner
{
    public class WaiterItemPageComponent
    {
        private IWebElement _waiterElement;
        public WaiterItemPageComponent(IWebElement element)
        {
            _waiterElement = element;
        }

        private IWebElement _removeButton => _waiterElement.FindElement(By.TagName("button"));

        public void ClickRemoveButton()
        {
            _removeButton.Click();
            Thread.Sleep(1000);
        }
    }
}
