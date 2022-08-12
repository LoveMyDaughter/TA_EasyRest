
namespace TestFramework.Tools
{
    public static class IWebElementExtentions
    {
        public static IWebDriver GetWebDriverFromWebElement(this IWebElement webElement)
        {
            var webDriver = ((IWrapsDriver)webElement).WrappedDriver;
            return webDriver;
        }
    }
}
