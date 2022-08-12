namespace TestFramework.Test
{
    public class BaseTest
    {
        IWebDriver Chromedriver;
        private static string baseUrl;


        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Chromedriver = new ChromeDriver();
            baseUrl = "http://localhost:3000"; //move to json
        }



        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Chromedriver.Quit();
        }
    }
}