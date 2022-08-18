using TestFramework.Pages.Moderator;

namespace TestFramework.Test
{
    public class ModeratorTests : BaseTest
    {
        private static string userEmail = "petermoderator@test.com";
        private static string userPassword = "1";
        IWebDriver driver = new ChromeDriver();


        [OneTimeSetUp]
        public void BeforeModeratorsTests()
        {
            UserLogin(driver, userEmail, userPassword);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        //[Repeat(2)]  // This restores the previous user's status (postcondition of test case)
        public void ChangeUserStatusTest()
        {
            // Arrange
            ModeratorPanelUsersPage moderatorPanelUsersPage = new ModeratorPanelUsersPage(driver);
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
