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
            SignInPage page = new SignInPage(Chromedriver);

            string url = "/log-in";
            string expected = $"{BasePage.baseUrl}/restaurants";

            password = "1111";
            email = "angelabrewer@test.com";


            //Act
            page.GoToUrl(url)
                .ClickEmailField()
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