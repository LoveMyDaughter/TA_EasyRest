namespace TestFramework.PageComponents.AdministratorPanelComponents
{
    public class WaitingForConfirmCardPageComponent 
    {
        private IWebElement _card { get; }

        public WaitingForConfirmCardPageComponent(IWebElement card)
        {
            _card = card;
        }

        private By _acceptButton => By.XPath(".//button//span[text()='Accept']");

        public WaitingForConfirmCardPageComponent ClickAcceptButton(int timeToWait)
        {
            var driver = _card.GetWebDriverFromWebElement();
            driver.WaitUntilElementIsVisible(_acceptButton, timeToWait)
                .Click();
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(_acceptButton));
            
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
            return this;
        }
    }
}
