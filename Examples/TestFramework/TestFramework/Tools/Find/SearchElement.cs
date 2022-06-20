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
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Tools.Find
{
    //public class SearchElement : ISearch
    public class SearchElement : ISearchStrategy
    {
        public ASearch Search { get; private set; }

        public SearchElement()
        {
            InitSearch();
        }

        private void InitSearch()
        {
            // TODO Use Factory Method
            Search = new SearchImplicit();
        }

        public void SetStrategy(ASearch search)
        {
            Search = search;
        }

        public void SetImplicitStrategy()
        {
            SetStrategy(new SearchImplicit());
        }

        public void SetExplicitStrategy()
        {
            SetStrategy(new SearchExplicit());
        }

        // Implemented Interface ISearch

        public bool StalenessOfWebElement(IWebElement webElement)
        {
            return Search.StalenessOfWebElement(webElement);
        }

        public bool InvisibilityOfWebElementLocated(By by)
        {
            return Search.InvisibilityOfWebElementLocated(by);
        }

        // Search Element

        public IWebElement Id(string id)
        {
            return Search.Id(id);
        }

        public IWebElement Name(string name)
        {
            return Search.Name(name);
        }

        public IWebElement XPath(string xpath)
        {
            return Search.XPath(xpath);
        }

        public IWebElement CssSelector(string cssSelector)
        {
            return Search.CssSelector(cssSelector);
        }

        public IWebElement ClassName(string className)
        {
            return Search.ClassName(className);
        }

        public IWebElement PartialLinkText(string partialLinkText)
        {
            return Search.PartialLinkText(partialLinkText);
        }

        public IWebElement LinkText(string linkText)
        {
            return Search.LinkText(linkText);
        }

        public IWebElement TagName(string tagName)
        {
            return Search.TagName(tagName);
        }

        // Get List

        public ICollection<IWebElement> Names(string name)
        {
            return Search.Names(name);
        }

        public ICollection<IWebElement> XPaths(string xpath)
        {
            return Search.XPaths(xpath);
        }

        public ICollection<IWebElement> CssSelectors(string cssSelector)
        {
            return Search.CssSelectors(cssSelector);
        }

        public ICollection<IWebElement> ClassNames(string className)
        {
            return Search.ClassNames(className);
        }

        public ICollection<IWebElement> PartialLinkTexts(string partialLinkText)
        {
            return Search.PartialLinkTexts(partialLinkText);
        }

        public ICollection<IWebElement> LinkTexts(string linkText)
        {
            return Search.LinkTexts(linkText);
        }

        public ICollection<IWebElement> TagNames(string tagName)
        {
            return Search.TagNames(tagName);
        }

    }
}
