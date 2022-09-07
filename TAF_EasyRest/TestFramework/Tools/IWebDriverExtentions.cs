
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

        public static void WaitUntilUrlIsChanged (this IWebDriver driver)
        {
            string currentUrl = driver.Url;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => driver.Url != currentUrl);
        }
    }

}
