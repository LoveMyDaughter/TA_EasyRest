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
    public abstract class ASearch : ISearch
    {
        public const long WITHOUT_MILLISECONDS = 10000000;
        public const int TIME_SLEEP_MILLISECONDS = 500;
        private const string NO_SUCH_ELEMENT = "Unable to locate element(s):";

        protected long GetSecondStamp()
        {
            return DateTime.Now.ToFileTime() / WITHOUT_MILLISECONDS;
        }

        // Abstract Methods

        public abstract IWebElement GetWebElement(By by);

        public abstract ICollection<IWebElement> GetWebElements(By by);

        public abstract bool StalenessOfWebElement(IWebElement IWebElement);

        public abstract bool InvisibilityOfWebElementLocated(By by);

        public abstract void ResetWaits();

        // Search WebElements

        private IWebElement SearchWebElement(By by)
        {
            try
            {
                return GetWebElement(by);
            }
            catch (Exception)
            {
                // TODO Develop Custom Exception
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        private ICollection<IWebElement> SearchWebElements(By by)
        {
            try
            {
                return GetWebElements(by);
            }
            catch (Exception)
            {
                // TODO Develop Custom Exception
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        // Search Element

        public IWebElement Id(string id)
        {
            return SearchWebElement(By.Id(id));
        }

        public IWebElement Name(string name)
        {
            return SearchWebElement(By.Name(name));
        }

        public IWebElement XPath(string xpath)
        {
            return SearchWebElement(By.XPath(xpath));
        }

        public IWebElement CssSelector(string cssSelector)
        {
            return SearchWebElement(By.CssSelector(cssSelector));
        }

        public IWebElement ClassName(String className)
        {
            return SearchWebElement(By.ClassName(className));
        }

        public IWebElement PartialLinkText(string partialLinkText)
        {
            return SearchWebElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement LinkText(string linkText)
        {
            return SearchWebElement(By.LinkText(linkText));
        }

        public IWebElement TagName(string tagName)
        {
            return SearchWebElement(By.TagName(tagName));
        }

        // Get IList

        public ICollection<IWebElement> Names(string name)
        {
            return SearchWebElements(By.Name(name));
        }

        public ICollection<IWebElement> XPaths(string xpath)
        {
            return SearchWebElements(By.XPath(xpath));
        }

        public ICollection<IWebElement> CssSelectors(string cssSelector)
        {
            return SearchWebElements(By.CssSelector(cssSelector));
        }

        public ICollection<IWebElement> ClassNames(string className)
        {
            return SearchWebElements(By.ClassName(className));
        }

        public ICollection<IWebElement> PartialLinkTexts(string partialLinkText)
        {
            return SearchWebElements(By.PartialLinkText(partialLinkText));
        }

        public ICollection<IWebElement> LinkTexts(string linkText)
        {
            return SearchWebElements(By.LinkText(linkText));
        }

        public ICollection<IWebElement> TagNames(string tagName)
        {
            return SearchWebElements(By.TagName(tagName));
        }
    }
}
