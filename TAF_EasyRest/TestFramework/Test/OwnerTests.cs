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

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }
    }
}