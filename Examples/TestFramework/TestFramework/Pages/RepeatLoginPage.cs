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
    public class RepeatLoginPage : LoginPage
    {
        public IWebElement InvalidLoginLabel { get; private set; }

        //public RepeatLoginPage(IWebDriver driver) : base(driver)
        public RepeatLoginPage() : base()
        {
            //InvalidLoginLabel = driver.FindElement(By.XPath("//div[contains(@style,'red')]"));
            InvalidLoginLabel = Search.XPath("//div[contains(@style,'red')]");
        }

        // PageObject Atomic

        // InvalidLoginLabel
        public string GetInvalidLoginLabelText()
        {
            return InvalidLoginLabel.Text;
        }

        public void ClickInvalidLoginLabel()
        {
            InvalidLoginLabel.Click();
        }

        // Business Logic
    }
}
