using TestFramework.Pages;


namespace TestFramework.Test
{
    public class Tests
    {
        IWebDriver Chromedriver;
        private static string password;
        private static string email;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Chromedriver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTestLoginToEasyrest() 
        {
            //Arrange
            HomePage page = new HomePage(Chromedriver);

            string url = "/log-in";
            string expected = $"{HomePage.baseUrl}/restaurants";

            password = "1111";
            email = "angelabrewer@test.com";


            //Act
            page.GoToUrl(url)
                .EnterData(email, password)
                .Click_LogIn_Button();

            Thread.Sleep(3000);


            //Assert
            Assert.AreEqual(expected, page.Get_CurrentUrl());
        }

        [Test]
        public void NegativeTestLoginToEasyrest()
        {
            //Arrange
            HomePage page = new HomePage(Chromedriver);

            string url = "/log-in";
            string expected = $"{HomePage.baseUrl}/restaurants";

            password = "12345678";
            email = "abc@1.com";


            //Act
            page.GoToUrl(url)
                .EnterData(email, password)
                .Click_LogIn_Button();

            Thread.Sleep(3000);

            
            //Assert
            Assert.AreEqual(expected, page.Get_CurrentUrl());
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Chromedriver.Quit();
        }
    }
}