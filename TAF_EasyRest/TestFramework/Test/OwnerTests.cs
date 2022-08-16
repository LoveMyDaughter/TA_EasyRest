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
            Assert.That(actual, Is.EqualTo(expected));
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ChromeDriver.Quit();
        }
    }
}