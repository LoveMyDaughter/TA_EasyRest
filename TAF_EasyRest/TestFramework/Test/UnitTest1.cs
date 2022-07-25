namespace TestFramework.Test
{
    [TestFixture]
    public class Tests
    {
        IWebDriver Chromedriver;
        private static string password;
        private static string email;
        private static string baseUrl;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Chromedriver = new ChromeDriver();
            baseUrl = "http://localhost:3000"; //move to json
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTestLoginToEasyrest() 
        {
            //Arrange
            SignInPage page = new SignInPage(Chromedriver);

            string expected = $"{baseUrl}/restaurants";

            password = "1111";
            email = "angelabrewer@test.com";


            //Act
            page.GoToUrl();
            page.ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickSignInButton();

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