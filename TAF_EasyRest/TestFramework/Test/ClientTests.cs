using TestFramework.Tools.GetData;
using TestFramework.Tools;

namespace TestFramework.Test
{
    [TestFixture]
    public class ClientTests : BaseTest
    {
        public IWebDriver driver { get; private set; }
        private string email;
        private string password;
        private string orderNumber;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            driver = new ChromeDriver();

            email = GetRoleCredentials.GetCredentials("Client").Email;
            password = GetRoleCredentials.GetCredentials("Client").Password;

            UserLogin(driver, email, password);
        }

        

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void DeclineOrderTest()
        {
            //Arrange
            CurrentOrdersPage currentOrdersPage = new CurrentOrdersPage(driver);

            currentOrdersPage.GoToUrl();

            //Act
            currentOrdersPage.ClickWaitingForConfirmButton(3);

            int expected = currentOrdersPage.CountOrders(3) - 1;
            
            currentOrdersPage.orders[0]
                .ExpandOrderField()
                .ClickDeclineButton(3);

            int actual = currentOrdersPage.CountOrders(3);

            orderNumber = currentOrdersPage.orders[0].number;
            Console.WriteLine(currentOrdersPage.orders[0].number);
            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            UserLogout(email);
            DBCleanup.ChangeOrderStatus("Waiting for confirm", orderNumber);
            driver.Quit();
        }
    }
}