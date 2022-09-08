using TestFramework.Tools;

namespace TestFramework.PageComponents.Owner
{
    public class AdministratorItemPageComponent
    {
        private IWebElement _adminElement;
        public AdministratorItemPageComponent(IWebElement element)
        {
            _adminElement = element;
        }

        public string? Name => _adminElement.FindElementSafe(By.XPath("./div/span"))?.Text;
        public string? Contacts => _adminElement.FindElementSafe(By.XPath("./div/p/span"))?.Text;
        private IWebElement _removeButton => _adminElement.FindElement(By.TagName("button"));
        public void ClickRemoveButton(int timeToWait)
        {
            var driver = _adminElement.GetWebDriverFromWebElement();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementToBeClickable(_removeButton))
                .Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.ElementExists(By.XPath("//h6")));
        }
    }
}
