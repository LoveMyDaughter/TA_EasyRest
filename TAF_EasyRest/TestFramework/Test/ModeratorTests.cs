using TestFramework.Pages.Moderator;

namespace TestFramework.Test
{
    public class ModeratorTests : BaseTest
    {
        public IWebDriver driver { get; private set; }

        [OneTimeSetUp]
        public void BeforeModeratorsTests()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--headless");
            //driver = new ChromeDriver(options);
            driver = new ChromeDriver();
            userEmail = GetRoleCredentials.GetCredentials("Moderator").Email;
            userPassword = GetRoleCredentials.GetCredentials("Moderator").Password;
            restaurantName = "Rest Created via DB";
            UserLogin(driver, userEmail, userPassword);
            AddRestaurant(restaurantName);
            AddRestaurantWithArchivedStatus(restaurantName);
            
        }

        [Test]
        [Category("Smoke")]
        [Category("Postitive")]
        public void ApproveRestaurantTest()
        {
            // Arrange
            ModeratorPanelRestaurantsPage restaurants = new ModeratorPanelRestaurantsPage(driver);
            int initialRestaurantsAmount = restaurants.ClickUnapprovedTab().RestaurantsCount();

            // Act
            restaurants.ClickUnapprovedTab().ClickApproveButton();
            int finalRestaurantsAmount = restaurants.ClickUnapprovedTab().RestaurantsCount();

            // Assert
            Assert.That(finalRestaurantsAmount == initialRestaurantsAmount - 1);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void RestoreRestaurantTest()
        {
            // Arrange
            ModeratorPanelRestaurantsPage restaurants = new ModeratorPanelRestaurantsPage(driver);
            restaurants.ModeratorLeftsideMenu.ClickRestaurantsButton();
            int initialRestaurantsAmount = restaurants.ClickArchivedTab().RestaurantsCount();

            // Act
            restaurants.ClickArchivedTab().FindAndClickRestoreButton();
            int finalRestaurantsAmount = restaurants.ClickArchivedTab().RestaurantsCount();

            // Assert
            Assert.That(finalRestaurantsAmount == initialRestaurantsAmount - 1);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void ChangeUserStatusTest()
        {
            // Arrange
            ModeratorPanelUsersPage moderatorPanelUsersPage = new ModeratorPanelUsersPage(driver);
            moderatorPanelUsersPage.GoToUrl();
            string initialStatus = moderatorPanelUsersPage.ShowUserStatus();

            // Act
            moderatorPanelUsersPage.FindAndClickPadlockButton();
            string finalStatus = moderatorPanelUsersPage.ShowUserStatus();

            // Assert
            Assert.That(initialStatus != finalStatus);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void ChangeOwnerStatusTest()
        {
            // Arrange
            ModeratorPanelOwnersPage moderatorPanelOwnersPage = new ModeratorPanelOwnersPage(driver);
            moderatorPanelOwnersPage.GoToUrl();
            string initialStatus = moderatorPanelOwnersPage.ShowOwnerStatus();

            // Act
            moderatorPanelOwnersPage.FindAndClickPadlockButton();
            string finalStatus = moderatorPanelOwnersPage.ShowOwnerStatus();

            // Assert
            Assert.That(initialStatus != finalStatus);
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
            DeleteRestaurant(restaurantName);
            UserLogout(userEmail);
        }

    }
}
