using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
