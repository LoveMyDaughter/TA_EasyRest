using TestFramework.Tools.DB;

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
                                  .CheckTheNumberOfOrdersInTheCurrentTab(10);

            orderId = administratorPanelPage.ClickWaitingForConfirmButton(10)
                                  .GetIdOfTheFirstOrder();
            orderStatus = "Waiting for confirm";

            //Act           
            administratorPanelPage.ClickWaitingForConfirmButton(10)
                                  .ExpandTheFirstOrder(10)
                                  .ClickAcceptButton(10);

            int numberOfOrdersAfterAccepting = administratorPanelPage.ClickWaitingForConfirmButton(10)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(10);

            //Assert
            Assert.That(numberOfOrdersBeforeAccepting, Is.EqualTo(numberOfOrdersAfterAccepting + 1));
        }

        [Test]
        [Category("Positive")]
        public void AssignAvailableWaiterForAcceptedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            int numberOfOrdersBeforeAssigning = administratorPanelPage.ClickAcceptedButton(10)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(10);
            Console.WriteLine(numberOfOrdersBeforeAssigning);

            orderId = administratorPanelPage.ClickAcceptedButton(10)
                                  .GetIdOfTheFirstOrder();
            orderStatus = "Accepted";

            //Act
            administratorPanelPage.ClickAcceptedButton(10)
                                  .ExpandTheFirstOrder(10)
                                  .SelectTheFirstWaiter(10)
                                  .ClickAssignButton(10);

            int numberOfOrdersAfterAssigning = administratorPanelPage.ClickAcceptedButton(10)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(10);

            Console.WriteLine(numberOfOrdersAfterAssigning);
            
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
