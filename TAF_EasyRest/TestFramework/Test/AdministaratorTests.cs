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
            userEmail = GetRoleCredentials.GetCredentials("Administrator").Email;
            userPassword = GetRoleCredentials.GetCredentials("Administrator").Password;
        }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            UserLogin(ChromeDriver, userEmail, userPassword);
            ChromeDriver.Manage().Window.Maximize();
        }

        [Test]
        [Category("Positive")]
        public void AcceptPreviouslyCreatedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            int numberOfOrdersBeforeAccepting = administratorPanelPage.ClickWaitingForConfirmButton(3)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(3);

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

        [Test]
        [Category("Positive")]
        public void AssignAvailableWaiterForAcceptedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            int numberOfOrdersBeforeAssigning = administratorPanelPage.ClickAcceptedButton(2)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(2);
            
            orderId = administratorPanelPage.ClickAcceptedButton(2)
                                  .GetIdOfTheFirstOrder();
            orderStatus = "Accepted";

            //Act
            administratorPanelPage.ClickAcceptedButton(2)
                                  .ExpandTheFirstOrder(3)
                                  .SelectTheFirstWaiter(4)
                                  .ClickAssignButton();

            int numberOfOrdersAfterAssigning = administratorPanelPage.ClickAcceptedButton(2)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(2);

            //Assert
            Assert.That(numberOfOrdersBeforeAssigning, Is.EqualTo(numberOfOrdersAfterAssigning + 1));
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
