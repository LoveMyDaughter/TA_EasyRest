
namespace TestFramework.Tools
{
    public static class IWebDriverExtentions
    {
        public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, By locator, int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            var el = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return el;
        }
    }
}
