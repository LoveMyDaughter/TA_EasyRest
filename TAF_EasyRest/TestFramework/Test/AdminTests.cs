namespace TestFramework.Test
{
    public class AdminTests : BaseTest
    {
        public IWebDriver driver { get; private set; }

        [OneTimeSetUp]
        public void BeforeAdminsTests()
        {
            driver = new ChromeDriver();
            userEmail = GetRoleCredentials.GetCredentials("Admin").Email;
            userPassword = GetRoleCredentials.GetCredentials("Admin").Password;
            UserLogin(driver, userEmail, userPassword);
        }

        [Test]
        [Category("Smoke")]
        [Category("Positive")]
        public void ChangeModeratorStatus()
        {
            Assert.Fail();
        }


        [OneTimeTearDown]
        public void AfterAdminsTests()
        {
            driver.Quit();
            UserLogout(userEmail);
        }


    }
}
