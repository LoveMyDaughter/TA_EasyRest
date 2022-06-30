
namespace TestFramework.Pages
{
    public class BasePage
    {
        public IWebDriver driver { get; }
        public static string baseUrl = "http://localhost:3000";


        public IWebElement Email_Field => driver.FindElement(By.Name("email"));
        public IWebElement Password_Field => driver.FindElement(By.Name("password"));
        public IWebElement LogIn_Button => driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/form/div/div[3]/div/button"));

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
            Password_Field.SendKeys(password);
            return this;
        }

        public BasePage Click_LogIn_Button()
        {
            LogIn_Button.Click();
            return this;
        }
    }
}
