namespace TestFramework.Test
{
    [TestFixture]
    public class ClientTests
    {
        public IWebDriver Chromedriver { get; private set; }
        

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Chromedriver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
            SignInPage signInPage = new SignInPage(Chromedriver);
            string email = "anitacharles@test.com";
            string password = "1111";

            signInPage.GoToUrl();
            signInPage.ClickEmailField()
                .SendKeysToEmailField(email)
                .ClickPasswordField()
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
        }

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void DeclineOrderTest()
        {
            Assert.IsTrue(true);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Chromedriver.Quit();
        }
    }
}