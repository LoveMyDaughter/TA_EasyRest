using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.Tools.DB;
namespace TestFramework.Test
{
    public class AdminTests : BaseTest
    {
        public IWebDriver driver { get; private set; }
        private string _fakeModeratorEmail = "fakemoder@test.com";

        [OneTimeSetUp]
        public void BeforeAdminsTests()
        {
            driver = new ChromeDriver();
            userEmail = GetRoleCredentials.GetCredentials("Admin").Email;
            userPassword = GetRoleCredentials.GetCredentials("Admin").Password;
            CreateModerator(_fakeModeratorEmail);
            UserLogin(driver, userEmail, userPassword);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void ChangeModeratorStatus()
        {
            // Arrange
            UserMenuHeaderButtonPageComponent userButton = new(driver);
            userButton.ClickUserMenuButton(1).ClickMyProfileButton(1);
            AdminPanelModeratorsPage moderators = new AdminPanelModeratorsPage(driver).AdminLeftsideMenu.ClickModeratorsButton();
            string initialStatus = moderators.GetModeratorStatus();

            // Act
            moderators.FindAndClickPadlockButton();
            string finalStatus = moderators.GetModeratorStatus();

            // Assert
            Assert.That(finalStatus != initialStatus);
        }

        [OneTimeTearDown]
        public void AfterAdminsTests()
        {
            driver.Quit();
            DBCleanup.DeleteUserByEmail(_fakeModeratorEmail);
            UserLogout(userEmail);
        }
    }
}
