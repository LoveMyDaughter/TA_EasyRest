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
using TestFramework.Tools;
using TestFramework.Tools.Find;

namespace TestFramework.Pages
{
    class UserDropDownMenu
    {
        protected ISearch Search { get; private set; }
        private IWebDriver driver;
        //
        public IWebElement ChangePassword
         //   { get { return driver.FindElement(By.CssSelector("a.change-password")); } }
            { get {                return Search.CssSelector("a.change-password"); } }
        public IWebElement ResetPassword
            { get { return driver.FindElement(By.CssSelector("a.reset-my-password")); } }
        //  { get { return Search.CssSelector("a.reset-my-password"); } }
        public IWebElement Logout
            { get { return driver.FindElement(By.XPath("//a[contains(@href,'/logout')]")); } }
        //   { get { return Search.XPath("//a[contains(@href,'/logout')]"); } }

        //public UserDropDownMenu(IWebDriver driver)
        public UserDropDownMenu()
        {
            // Search = Application.Get().Search;
            this.driver = driver;
        }
    }

    public abstract class ACommonComponent : ATopComponent
    {
        public IWebElement LoginName //{ get; private set; }
            //{ get { return driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)")); } }
            { get { return Search.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)"); } }
        public IWebElement DropDownMenu //{ get; private set; }
            //{ get { return driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")); } }
            { get { return Search.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle"); } }
        private UserDropDownMenu userDropDownMenu;

        //public ACommonComponent(IWebDriver driver) : base(driver)
        public ACommonComponent() : base()
        {
            // Classic Page Object
            //LoginAccount = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)"));
            //MenuAccount = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle"));
            //
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = LoginName;
            temp = DropDownMenu;
        }

        // PageObject Atomic

        // LoginName
        public string GetLoginNameText()
        {
            return LoginName.Text;
        }

        public void ClickLoginName()
        {
            LoginName.Click();
        }

        // DropDownMenu
        public void ClickDropDownMenu()
        {
            DropDownMenu.Click();
        }

        // Functional
        public void OpenDropDownMenu()
        {
            ClickLoginName();
            ClickDropDownMenu();
            //userDropDownMenu = new UserDropDownMenu(driver);
            userDropDownMenu = new UserDropDownMenu();
        }

        // ChangePassword
        public IWebElement GetChangePassword()
        {
            OpenDropDownMenu();
            return userDropDownMenu.ChangePassword;
        }

        public string GetChangePasswordText()
        {
            return GetChangePassword().Text;
        }

        public void ClickChangePassword()
        {
            GetChangePassword().Click();
        }

        // ResetPassword
        public IWebElement GetResetPassword()
        {
            OpenDropDownMenu();
            return userDropDownMenu.ResetPassword;
        }

        public string GetResetPasswordText()
        {
            return GetResetPassword().Text;
        }

        public void ClickResetPassword()
        {
            GetResetPassword().Click();
        }

        // Logout
        public IWebElement GetLogout()
        {
            OpenDropDownMenu();
            return userDropDownMenu.Logout;
        }

        public string GetLogoutText()
        {
            return GetLogout().Text;
        }

        public void ClickLogout()
        {
            GetLogout().Click();
        }

        // Business Logic
        public LoginPage Logout()
        {
            ClickLogout();
            //return new LoginPage(driver);
            return new LoginPage();
        }

    }
}
