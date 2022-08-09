using TestFramework.Tools;

namespace TestFramework.Test
{
    [TestFixture]
    public class Tests
    {
        IWebDriver Chromedriver;

        private static string name;
        private static string email;
        private static string password;
        
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



        [Test]
        public void SignUp()
        {
            //Arrange
            SignUpPage page = new SignUpPage(Chromedriver);

            string expected = $"{baseUrl}/log-in";

            name = "Name for Test 3";
            password = "12345678";
            email = "test-3@gmail.com";


            //Act
            page.GoToUrl();
            page.ClickNameField()
                .SendKeysToNameField(name)
                .ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickConfirmPasswordField()
                .SendKeysToConfirmPasswordField(password)
                .ClickCreateAccountButton();

            Thread.Sleep(1000);


            //Assert
            Assert.AreEqual(expected, page.Get_CurrentUrl());
        }

        //[TearDown]
        public void AfterEveryTest()
        {
            DBCleanup.DeleteUserByEmail(email);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            DBCleanup.DeleteUserByEmail(email);
            Chromedriver.Quit();
        }

    }
}