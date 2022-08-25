using TestFramework.PageComponents;

namespace TestFramework.Test
{
    [TestFixture]
    public class OwnerTests : BaseTest
    {
        public IWebDriver driver { get; private set; }

        [OneTimeSetUp]
        public void BeforeModeratorsTests()
        {
            driver = new ChromeDriver();
            userEmail = "jasonbrown@test.com";
            userPassword = "1111";
            UserLogin(driver, userEmail, userPassword);
        }

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void RemoveWaiterTest()
        {
            //Arrange
            OwnerPanelRestaurantsPage ownerPanelRestaurantsPage = new OwnerPanelRestaurantsPage(driver);

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
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Smoke")]
        [Category("Positive")]
        [Test]
        public void AddAdministratorTest()
        {
            //Arrange
            OwnerPanelRestaurantsPage ownerPanelRestaurantsPage = new OwnerPanelRestaurantsPage(driver);
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
            Assert.That(actual?.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Contacts, Is.EqualTo($"{expected.PhoneNumber} / {expected.Email}"));
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }
    }
}