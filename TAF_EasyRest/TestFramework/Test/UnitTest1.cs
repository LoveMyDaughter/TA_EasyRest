//using OpenQA.Selenium.Chrome;

namespace TestFramework.Test
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTestLoginToEasyrest() 
        {
            driver.Navigate().GoToUrl("http://localhost:3000/log-in");
            driver.FindElement(By.Name("email")).SendKeys("angelabrewer@test.com");
            driver.FindElement(By.Name("password")).SendKeys("1111"+Keys.Enter); Thread.Sleep(3000);
            Assert.AreEqual("http://localhost:3000/restaurants", driver.Url);
        }

        [Test]
        public void NegativeTestLoginToEasyrest()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/log-in");
            driver.FindElement(By.Name("email")).SendKeys("abc@1.com");
            driver.FindElement(By.Name("password")).SendKeys("12345678" + Keys.Enter); Thread.Sleep(3000);
            Assert.AreEqual("http://localhost:3000/restaurants", driver.Url);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }
    }
}