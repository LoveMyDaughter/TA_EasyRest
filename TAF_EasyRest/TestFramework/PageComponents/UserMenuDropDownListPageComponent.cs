﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.PageComponents 
{
    internal class UserMenuDropDownListPageComponent
    {
        protected IWebDriver driver { get; set; }
        protected static TimeSpan timeout = TimeSpan.FromSeconds(3);
        protected static WebDriverWait wait { get; set; }


        public UserMenuDropDownListPageComponent(IWebDriver driver) 
        {
            wait = new WebDriverWait(driver, timeout);
            this.driver = driver;
        }

        private IWebElement _MyProfile = wait.Until(drv => drv.FindElement(By.XPath("//a[@role='menuitem']")));
        private IWebElement _LogOut = wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Log Out']")));

        public UserMenuDropDownListPageComponent ClickGoToMyProfileButton()
        {
            _MyProfile.Click();
            return this;
        }

        public UserMenuDropDownListPageComponent ClickLogOutButton()
        {
            _LogOut.Click();
            return this;
        }
    }
}
