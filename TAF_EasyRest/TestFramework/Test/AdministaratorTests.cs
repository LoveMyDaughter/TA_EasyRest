namespace TestFramework.Test
{
    [TestFixture]
    public class AdministaratorTests : BaseTest
    {
        public IWebDriver ChromeDriver { get; private set; }
        private string orderId;
        private string orderStatus;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeDriver = new ChromeDriver();
            userEmail = "eringonzales@test.com";
            userPassword = "1";
        }

        [SetUp]
        public void SetUp()
        {
            UserLogin(ChromeDriver, userEmail, userPassword);
            ChromeDriver.Manage().Window.Maximize();
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void AcceptPreviouslyCreatedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            int numberOfOrdersBeforeAccepting = administratorPanelPage.ClickWaitingForConfirmButton(3)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(2);


            orderId = administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .GetIdOfTheFirstOrder();
            orderStatus = "Waiting for confirm";

            //Act           
            administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .ExpandTheFirstOrder(2)
                                  .ClickAcceptButton(2);

            int numberOfOrdersAfterAccepting = administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(1);

            //Assert
            Assert.That(numberOfOrdersBeforeAccepting, Is.EqualTo(numberOfOrdersAfterAccepting + 1));
        }

        [TearDown]
        public void AfterTests()
        {
            UserLogout(userEmail);
            ChromeDriver.Quit();
            DBCleanup.ChangeOrderStatus(orderId, orderStatus);
        }
    }
}
