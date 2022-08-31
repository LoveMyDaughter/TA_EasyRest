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
        private string _restaurantName;

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

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void AddRestaurant()
        {
            //Arrange
            NewRestaurantPage newRestaurantPage = new NewRestaurantPage(driver);

            newRestaurantPage.GoToUrl();

            _restaurantName = "name1";
            string restaurantAdress = "adress1";

            //Act
            newRestaurantPage.ClickAddButton(3)
                .ClickNameField(3)
                .SendKeysNameField(_restaurantName)
                .ClickAdressField(3)
                .SendKeysAdressField(restaurantAdress)
                .ClickAddButton();

            DBCleanup.ChangeUserRole(1, email);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            UserLogout(email);
            driver.Quit();
            DBCleanup.ChangeOrderStatusByNumber("Waiting for confirm", orderNumber);
            //DBCleanup.DeleteRestaurantByName(_restaurantName);
        }
    }
}