using TestFramework.PageComponents;

namespace TestFramework.Test
{
    [TestFixture]
    public class OwnerTests
    {
        public IWebDriver ChromeDriver { get; private set; }

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeDriver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
            SignInPage signInPage = new SignInPage(ChromeDriver);
            string email = "jasonbrown@test.com";
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
        public void RemoveWaiterTest()
        {
            //Arrange
            OwnerPanelRestaurantsPage ownerPanelRestaurantsPage = new OwnerPanelRestaurantsPage(ChromeDriver);

            ownerPanelRestaurantsPage.GoToUrl();

            //Act
            OwnerEditRestaurantPage editRestaurantPage = ownerPanelRestaurantsPage.RestaurantItems[0]
                .ClickThreeDotButton()
                .ClickManageButton();

            ManageWaitersPage manageWaitersPage = editRestaurantPage.ManageRestaurantPageComponent.ClickWaitersButton();
            
            int expected = manageWaitersPage.WaiterItems.Count - 1;
            manageWaitersPage.WaiterItems[0].ClickRemoveButton();
            int actual = manageWaitersPage.WaiterItems.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void AddAdministratorTest()
        {
            //Arrange
            OwnerPanelRestaurantsPage ownerPanelRestaurantsPage = new OwnerPanelRestaurantsPage(ChromeDriver);
            ownerPanelRestaurantsPage.GoToUrl();
            var expected = new
            {
                Name = "Test Admin",
                Email = "admin.test@test.com",
                Password = "12345678",
                PhoneNumber = "0987654321"
            };

            //Act
            OwnerEditRestaurantPage editRestaurantPage = ownerPanelRestaurantsPage.RestaurantItems[0]
                .ClickThreeDotButton()
                .ClickManageButton();

            CreateNewAdministratorPageComponent createAdminComponent = editRestaurantPage.ManageRestaurantPageComponent
                .ClickAdministratorsButton()
                .ClickAddAdministratorButton();

            ManageAdministratorPage manageAdminPage = createAdminComponent.SendKeysToFields(expected.Name, expected.Email, expected.Password, expected.PhoneNumber)
                .ClickAddButton();

            var actual = manageAdminPage.AdministratorItem;

            //Assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual($"{expected.PhoneNumber} / {expected.Email}", actual.Contacts);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ChromeDriver.Quit();
        }
    }
}