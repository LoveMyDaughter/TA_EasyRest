using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    public class RegistratorHomePage : ACommonComponent
    {
        public IWebElement Home
            //{ get { return driver.FindElement(By.CssSelector("a.glyphicon.glyphicon-home")); }}
            { get { return Search.CssSelector("a.glyphicon.glyphicon-home"); }}
        public IWebElement SearchResources
            //{ get { return driver.FindElement(By.XPath("//a[contains(@href,'/searchOnMap')]")); } }
            { get { return Search.XPath("//a[contains(@href,'/searchOnMap')]"); } }
        public IWebElement SubclassObjects
            //{ get { return driver.FindElement(By.XPath("//a[contains(@href,'/show-res-types')]")); } }
            { get { return Search.XPath("//a[contains(@href,'/show-res-types')]"); } }
        public IWebElement AddNewResource
            //{ get { return driver.FindElement(By.XPath("//a[contains(@href,'/new')]")); } }
            { get { return Search.XPath("//a[contains(@href,'/new')]"); } }

        //public RegistratorHomePage(IWebDriver driver) : base(driver)
        public RegistratorHomePage() : base()
        {
            //VerifyWebElements();
        }

        // PageObject Atomic

        // Home
        // SearchResources
        // SubclassObjects
        // AddNewResource

        // Business Logic

    }
}
