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

        public void ClickRemoveButton(int timeToWait)
        {
            var driver = _waiterElement.GetWebDriverFromWebElement();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementToBeClickable(_removeButton))
                .Click();
            Thread.Sleep(5000);
        }
    }
}
