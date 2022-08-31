using TestFramework.Tools.GetData;
using TestFramework.Tools.DB;

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
            orderNumber = currentOrdersPage.orders[0].number;

            currentOrdersPage.orders[0]
                .ExpandOrderField()
                .ClickDeclineButton(3);

            int actual = currentOrdersPage.CountOrders(3);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ReorderTest()
        {
            //Arrange
            OrderHistoryPage orderHistoryPage = new OrderHistoryPage(driver);

            orderHistoryPage.GoToUrl();

            //Act
            orderHistoryPage.ClickHistoryButton(3);

            int expected = DBSelections.GetOrdersCountByStatus(email, "Waiting for confirm");

            orderHistoryPage.orders[0]
                .ExpandOrderDetails()
                .ClickReorderButton(3)
                .ClickSubmitButton(3);

            int actual = DBSelections.GetOrdersCountByStatus(email, "Waiting for confirm") - 1;

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            UserLogout(email);
            
            DBCleanup.ChangeOrderStatusByNumber("Waiting for confirm", orderNumber);
            driver.Quit();
        }
    }
}