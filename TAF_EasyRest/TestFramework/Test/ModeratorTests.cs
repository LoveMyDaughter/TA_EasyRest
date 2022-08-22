using TestFramework.Pages.Moderator;

namespace TestFramework.Test
{
    public class ModeratorTests : BaseTest
    {
        public IWebDriver driver { get; private set; }

        [OneTimeSetUp]
        public void BeforeModeratorsTests()
        {
            driver = new ChromeDriver();
            userEmail = "petermoderator@test.com";
            userPassword = "1";
            UserLogin(driver, userEmail, userPassword);
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
            UserLogout(userEmail);
            driver.Quit();
        }

    }
}
