namespace TestFramework.Test
{
    [TestFixture]
    public class AdministaratorTests : BaseTest
    {
        public IWebDriver ChromeDriver { get; private set; }

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeDriver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            string email = "eringonzales@test.com";
            string password = "1";
            UserLogin(ChromeDriver, email, password);
            //Thread.Sleep(4000);
            SignInPage signInPage = new SignInPage(ChromeDriver);
            signInPage.WaitUntilPageIsLoaded(4);
        }

        [Test]
        public void AcceptPreviouslyCreatedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            administratorPanelPage.GoToUrl();
            Thread.Sleep(4000);
            //Act
            //Assert
        }

        [TearDown]
        public void AfterTests()
        {
            ChromeDriver.Quit();
        }
    }
}
