﻿using TestFramework.Tools.GetData;
namespace TestFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver { get; private set; }
        protected static string baseUrl => GetUrls.getUrl("basePage").Url;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool atPage(string expectUrl)
        {
            if (expectUrl == driver.Url)
                return true;
            return false;
        }

        public string Get_CurrentUrl()
        {
            return driver.Url;
        }

        //override where url != baseurl
        public virtual void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void WaitUntilPageIsLoaded(int timeToWait)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
