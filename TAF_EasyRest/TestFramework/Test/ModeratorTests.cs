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
        //[Repeat(2)]  // This restores the previous user's status (postcondition of test case)
        public void ChangeUserStatusTest()
        {
            // Arrange
            ModeratorPanelUsersPage moderatorPanelUsersPage = new ModeratorPanelUsersPage(driver); Thread.Sleep(2000);
            moderatorPanelUsersPage.GoToUrl(); Thread.Sleep(1000);
            string initialStatus = moderatorPanelUsersPage.ShowUserStatus();

            // Act
            moderatorPanelUsersPage.FindAndClickPadlockButton(); Thread.Sleep(1000);
            string finalStatus = moderatorPanelUsersPage.ShowUserStatus();

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
