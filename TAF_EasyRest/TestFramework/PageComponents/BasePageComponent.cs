using TestFramework.Tools;

namespace TestFramework.PageComponents
{
    public class BasePageComponent
    {
        protected IWebElement WaitUntilElementIsVisible(By locator, IWebDriver driver, int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            var el = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return el;
        }
        
        protected IWebElement WaitUntilElementIsVisible(By locator, IWebElement parent, int timeToWait)
        {
            var driver = parent.GetWebDriverFromWebElement();
            return WaitUntilElementIsVisible(locator, driver, timeToWait);
        }


        protected void WaitUntilCollectionIsFilled(IReadOnlyCollection<IWebElement> elements, IWebDriver driver, int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(d => elements.Count > 0);
        }
    }
}
