using TestFramework.Tools;

namespace TestFramework.Test
{
    [TestFixture]
    public class Tests
    {
        IWebDriver Chromedriver;

        private static string baseUrl;
        private string userEmail;

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

            string expected = $"{baseUrl}/profile/restaurants";
            string email = "antront@ukr.net";
            string password = "12345678";

            //Act
            page.GoToUrl();
            page.ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickSignInButton();

            Thread.Sleep(1000);


            //Assert
            Assert.AreEqual(expected, page.Get_CurrentUrl());
        }


    [Test]
    public void SignUp()
    {
        //Arrange
        SignUpPage page = new SignUpPage(Chromedriver);

        string expected = $"{baseUrl}/log-in";

        string name = "Name for Test 3";
        string password = "12345678";
        string email = "test-3@gmail.com";
        userEmail = email;


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


    [OneTimeTearDown]
    public void AfterAllTests()
    {
        DBCleanup.DeleteUserByEmail(userEmail);
        Chromedriver.Quit();
    }

}
}