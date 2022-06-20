using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Tools.Find
{
    public interface ISearch
    {

        bool StalenessOfWebElement(IWebElement IWebElement);

        bool InvisibilityOfWebElementLocated(By by);

        // Search Element

        IWebElement Id(string id);

        IWebElement Name(string name);

        IWebElement XPath(string xpath);

        IWebElement CssSelector(string cssSelector);

        IWebElement ClassName(string className);

        IWebElement PartialLinkText(string partialLinkText);

        IWebElement LinkText(string linkText);

        IWebElement TagName(string tagName);

        // Get List

        ICollection<IWebElement> Names(string name);

        ICollection<IWebElement> XPaths(string xpath);

        ICollection<IWebElement> CssSelectors(string cssSelector);

        ICollection<IWebElement> ClassNames(string className);

        ICollection<IWebElement> PartialLinkTexts(string partialLinkText);

        ICollection<IWebElement> LinkTexts(string linkText);

        ICollection<IWebElement> TagNames(string tagName);
    }
}
