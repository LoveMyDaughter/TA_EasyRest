namespace TestFramework.Test
{
    [TestFixture]
    public class AdministaratorTests : BaseTest
    {
        public IWebDriver ChromeDriver { get; private set; }
        string email = "eringonzales@test.com";
        string password = "1";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ChromeDriver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            UserLogin(ChromeDriver, email, password);
            ChromeDriver.Manage().Window.Maximize();
            Thread.Sleep(3000);// to be removed
        }

        [Test]
        public void AcceptPreviouslyCreatedOrderPositiveTest()
        {
            //Arrange
            AdministratorPanelPage administratorPanelPage = new AdministratorPanelPage(ChromeDriver);
            administratorPanelPage.GoToUrl(); Thread.Sleep(2000);
            int numberOfOrdersBeforeAccepting = administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(2);

            //Act           
            administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .ExpandTheFirstOrder(2)
                                  .ClickAcceptButton(2);

            int numberOfOrdersAfterAccepting = administratorPanelPage.ClickWaitingForConfirmButton(2)
                                  .CheckTheNumberOfOrdersInTheCurrentTab(1);

            //Thread.Sleep(3000);

            //Assert
            Console.WriteLine($"Before = { numberOfOrdersBeforeAccepting}");
            Console.WriteLine($"After = {numberOfOrdersAfterAccepting}");
            Assert.That(numberOfOrdersBeforeAccepting, Is.EqualTo(numberOfOrdersAfterAccepting + 1));
            //Assert.AreEqual(numberOfOrdersBeforeAccepting, numberOfOrdersAfterAccepting + 1);
        }

        [TearDown]
        public void AfterTests()
        {
            ChromeDriver.Quit();
            //DBCleanup.ChangeOrderStatus("91", "Waiting for confirm");
        }
    }
}
