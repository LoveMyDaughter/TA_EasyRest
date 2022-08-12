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
            email = "eringonzales@test.com";

            //Act
            page.GoToUrl();
            page.ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickSignInButton();

            AdministratorPanelPage admPage = new AdministratorPanelPage(Chromedriver);
            admPage.ClickWaitingForConfirmButton2(3)
                .ExpandTheFirstOrder(5)
                .ClickAcceptButton(3);

            Thread.Sleep(9000);


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