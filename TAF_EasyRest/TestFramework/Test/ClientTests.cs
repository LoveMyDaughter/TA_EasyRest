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
            signInPage.SendKeysToEmailField(email)
                .SendKeysToPasswordField(password)
                .ClickSignInButton();
            Thread.Sleep(3000);
        }

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void DeclineOrderTest()
        {
            //Arrange
            CurrentOrdersPage currentOrdersPage = new CurrentOrdersPage(Chromedriver);

            currentOrdersPage.GoToUrl();
            Thread.Sleep(1000); //change to waiter

            //Act
            currentOrdersPage.ClickWaitingForConfirmButton();

            int expected = currentOrdersPage.ÑountOrders() - 1;

            currentOrdersPage.orders[0]
                .ExpandOrderField() //tread.sleep in method
                .ClickDeclineButton();

            Thread.Sleep(1000);
            int actual = currentOrdersPage.ÑountOrders();

            currentOrdersPage.UserButton
                .ClickUserMenuButton(3)
                .ClickLogOutButton(3);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Chromedriver.Quit();
        }
    }
}