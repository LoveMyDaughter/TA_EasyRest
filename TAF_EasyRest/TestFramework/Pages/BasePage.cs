using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    public class BasePage
    {
        public IWebDriver driver { get; }
        public static string baseUrl = "http://localhost:3000";


        public IWebElement Email_Field => driver.FindElement(By.Name("email"));
        public IWebElement Password_Field => driver.FindElement(By.Name("password"));

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BasePage GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(baseUrl + url);
            return this;
        }

        public string Get_CurrentUrl()
        {
            return driver.Url;
        }

        public BasePage EnterData(string email, string password)
        {
            Email_Field.Click();
            Email_Field.SendKeys(email);
            Password_Field.Click();
            Password_Field.SendKeys(password + Keys.Enter);
            return this;
        }
    }
}
