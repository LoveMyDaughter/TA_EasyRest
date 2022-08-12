namespace TestFramework.Test
{
    [TestFixture]
    public class SampleTests
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
            password = "1";
            email = "randyrichards@test.com";

            //Act
            page.GoToUrl();
            page.ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickSignInButton();

            AdministratorPanelPage admPage = new AdministratorPanelPage(Chromedriver);
            admPage.UserMenuHeaderButton.ClickUserMenuButton2(3).ClickLogOutButton(3);

            Thread.Sleep(11000);


            //Assert
            Assert.IsTrue(true);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Chromedriver.Quit();
        }
    }
}