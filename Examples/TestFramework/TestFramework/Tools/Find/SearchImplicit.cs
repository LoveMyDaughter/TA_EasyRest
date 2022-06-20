using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Data.Application;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Tools.Find
{
    //public class SearchImplicit : ASearch, ISearch
    public class SearchImplicit : ASearch
    {
        public SearchImplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            // TODO ImplicitLoadTimeOut, ImplicitScriptTimeOut
        }

        public override bool StalenessOfWebElement(IWebElement element)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.ImplicitWaitTimeOut)
                   && !result)
            {
                try
                {
                    result = element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.ImplicitWaitTimeOut)
                  && !result)
            {
                try
                {
                    result = GetWebElement(by) == null || !GetWebElement(by).Enabled || !GetWebElement(by).Displayed;
                }
                //catch (StaleElementReferenceException)
                catch (Exception)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }
    }
}
