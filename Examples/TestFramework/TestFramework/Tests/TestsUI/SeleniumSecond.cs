using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.Pages;
using TestFramework.Data.Users;
using TestFramework.Tools;

namespace TestFramework
{
    //[TestFixture]
    public class SeleniumSecond
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get();
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/login");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/logout");
        }

      //  [Test]
        public void LoginTest1()
        {
            // Steps
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.AreEqual("work1",
                driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)")).Text);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            driver.FindElement(By.XPath("//a[contains(@href,'/logout')]")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.True(driver.FindElement(By.CssSelector("div.signin-container img"))
                .GetAttribute("src").Contains("ukraine_logo2.gif"));
        }

        //[Test]
        public void LoginTest2()
        {
            // Steps
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.AreEqual("work",
                driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)")).Text);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            driver.FindElement(By.XPath("//a[contains(@href,'/logout')]")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.True(driver.FindElement(By.CssSelector("div.signin-container img"))
                .GetAttribute("src").Contains("ukraine_logo2.gif"));
        }

        //[Test]
        public void LoginTest3()
        {
            // Steps
            //
            //IWebElement login = driver.FindElement(By.Id("login"));
            //login.Click();
            //login.Clear();
            //login.SendKeys("Hello");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            // For Example, AJAX Refresh Element
            //driver.Navigate().Refresh();
            //
            //login.Click();
            //login.Clear();
            //login.SendKeys("work");
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("Hello");
            Thread.Sleep(1000);
            //
            // For Example, AJAX Refresh Element
            driver.Navigate().Refresh();
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            //driver.FindElement(By.Id("password")).Submit();
            Thread.Sleep(1000); // For Presentation ONLY
            //
        }

        //[Test]
        public void LoginTest4()
        {
            // Steps
            //driver.FindElement(By.Id("login")).Click();
            //driver.FindElement(By.Id("login")).Clear();
            //driver.FindElement(By.Id("login")).SendKeys("work");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.Id("password")).Click();
            //driver.FindElement(By.Id("password")).Clear();
            //driver.FindElement(By.Id("password")).SendKeys("qwerty");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            //
            //LoginPage loginPage = new LoginPage(driver);
            //loginPage.SetLoginInputClear("work");
            //loginPage.SetPasswordInputClear("qwerty");
            //loginPage.ClickSigninButton();
            //
            //new LoginPage(driver)
            //    .SetLoginInputClear("work")
            //    .SetPasswordInputClear("qwerty")
            //    .ClickSigninButton();
            //
            //new LoginPage(driver)
            new LoginPage()
            //    .successRegistratorLogin("work", "qwerty");
                .successRegistratorLogin(UserRepository.Get().Registered());
            //
            Thread.Sleep(4000); // For Presentation ONLY
            //
        }

        //[Test]
        public void LoginTest5()
        {
            // Steps
            //RegistratorHomePage registratorHomePage = new LoginPage(driver)
            RegistratorHomePage registratorHomePage = new LoginPage()
            //    .successRegistratorLogin("work", "qwerty");
                .successRegistratorLogin(UserRepository.Get().Registered());
            
            // Check
            Assert.AreEqual("work", registratorHomePage.GetLoginNameText());
            
            // Steps
            LoginPage loginPage = registratorHomePage.Logout();
            
            // Check
            //Assert.True(loginPage.GetLogoPictureSrcAttributeText()
            //    .Contains("ukraine_logo2.gif"));
       //Покращили попередню перевірку і винесли тестові дані в константу LoginPage.IMAGE_NAME
            Assert.True(loginPage.GetLogoPictureSrcAttributeText()
                .Contains(LoginPage.IMAGE_NAME));
        }

        //[Test]
        public void LoginTest6_negative_case()
        {
            // Steps
            //RepeatLoginPage repeatLoginPage = new LoginPage(driver)

            //прописуємо новий клас RepeatLoginPage для сторінки з повідомленням про невірну спробу логіну
            RepeatLoginPage repeatLoginPage = new LoginPage()

            //    .unsuccessfulLogin("hahaha", "qwerty");
       //виносимо тестові дані користувачів у клас UserRepository
                .unsuccessfulLogin(UserRepository.Get().Invalid());

            // Check
            //перевіряємо, що відображається повідомлення п
            Assert.True(repeatLoginPage.GetInvalidLoginLabelText().Length > 0);
        }

        //[Test]
        public void LoginTest7_PageFactory()
        {
            // PageFactory. Init Attribute
            //LoginPage loginPage = new LoginPage(driver);
            LoginPage loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.LoginInput_PageFactoryExample.Click();

            // Steps
            //RegistratorHomePage registratorHomePage = new LoginPage(driver)
            RegistratorHomePage registratorHomePage = new LoginPage()
            //RegistratorHomePage registratorHomePage = loginPage
            //    .successRegistratorLogin("work", "qwerty");
                .successRegistratorLogin(UserRepository.Get().Registered());
            
            // Check
            Assert.AreEqual("work", registratorHomePage.GetLoginNameText());
        }

        //[Test]
        public void LoginTest8_()
        {
            // Steps
            //LoginPage loginPage = new LoginPage(driver)

            LoginPage loginPage = new LoginPage()
                .SetLoginInputClear("work")
                .SetPasswordInputClear("qwerty");


            driver.Navigate().Refresh();
            loginPage
                .SetLoginInputClear("work")
                .SetPasswordInputClear("qwerty")
                .ClickSigninButton();
        }

        //[Test]
        public void SimpleTest1()
        {
            // 1. Classic Constructor
            //User user = new User(
            //    "firstname", "lastname", "email",
            //    "phone", "addressMain", "city",
            //    "postcode", "coutry", "regionState",
            //    "password", true);
            //
            // 2. Default public Constructor
            //User user = new User();
            //user.Firstname = "firstname";
            //user.Lastname = "lastname";
            //user.Email = "email";
            //user.Phone = "phone";
            //user.AddressMain = "addressMain";
            //user.City = "city";
            //user.Postcode = "postcode";
            //user.Coutry = "coutry";
            //user.RegionState = "regionState";
            ////user.Password = "password";
            //user.Subscribe = true;
            //user.Fax = "fax";
            //user.Company = "company";
            //user.AddressAdd = "addressAdd";
            //
            //Console.WriteLine("Login= " + user.Email + "   Password= " + user.Password);
            //
            // 3. Add Setters, Getters
            //User user = new User();
            //user.SetFirstname("firstname");
            //user.SetLastname("lastname");
            //user.SetEmail("email");
            //user.SetPhone("phone");
            //user.SetAddressMain("addressMain");
            //user.SetCity("city");
            //user.SetPostcode("postcode");
            //user.SetCoutry("coutry");
            //user.SetRegionState("regionState");
            //user.SetPassword("password");
            //user.SetSubscribe(true);
            //user.SetFax("fax");
            //user.SetCompany("company");
            //user.SetAddressAdd("addressAdd");
            //
            // 4. Fluent Interface
            //User user = new User()
            //    .SetFirstname("firstname")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    //.SetPassword("password")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd");
            //
            // 5. Static Factory
            //User user = User.Get()
            //    .SetFirstname("firstname")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    //.SetPassword("password5")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd");
            //
            // 6. Builder
            //User user = User.Get()
            //    .SetFirstname("Firstname")
            //    .SetLastname("Lastname")
            //    .SetEmail("Email")
            //    .SetPhone("123456789")
            //    .SetAddressMain("AddressMain")
            //    .SetCity("City")
            //    .SetPostcode("1234567")
            //    .SetCoutry("Ukraine")
            //    .SetRegionState("Ukr")
            //    .SetPassword("qwerty")
            //    .SetSubscribe(true)
            //    .SetFax("12345")
            //    .SetCompany("Company")
            //    .SetAddressAdd("AddressAdd")
            //    .build();
            //Console.WriteLine("Login= " + user.SetEmail("hahaha")); // Defect
            //
            // 7. Dependency Inversion
            //IUser user = User.Get()
            //    .SetLogin("Login")
            //    .SetFirstname("Firstname")
            //    .SetLastname("Lastname")
            //    .SetEmail("Email")
            //    .SetPhone("123456789")
            //    .SetAddressMain("AddressMain")
            //    .SetCity("City")
            //    .SetPostcode("1234567")
            //    .SetCoutry("Ukraine")
            //    .SetRegionState("Ukr")
            //    .SetPassword("qwerty")
            //    .SetSubscribe(true)
            //    .SetFax("12345")
            //    .SetCompany("Company")
            //    .SetAddressAdd("AddressAdd")
            //    .Build();
            //Console.WriteLine("Login= " + user.SetEmail("hahaha")); // Error
            //Console.WriteLine("Login= " + ((User)user).SetEmail("hahaha")); // (User)user Code Smell
           
            // 8. Singleton. Repository
            IUser user = UserRepository.Get().Registered();
            Console.WriteLine("Login= " + user.GetLogin() + "   Password= " + user.GetPassword());
        }

        // DataProvider
        private static readonly object[] ValidUsers =
        {
            new object[] { UserRepository.Get().Registered() },
            new object[] { UserRepository.Get().Registered() }
        };

        // DataProvider
        private static readonly object[] ExternalValidUsers =
            //ListUtils.ToMultiArray(UserRepository.Get().FromCsv());
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        //[Test, TestCaseSource(nameof(ValidUsers))]
        //[Test, TestCaseSource("ValidUsers")]
        //[Test, TestCaseSource("ExternalValidUsers")]
        public void LoginTest9(IUser validRegistrator)
        {
            // Steps
            //RegistratorHomePage registratorHomePage = new LoginPage(driver)
            RegistratorHomePage registratorHomePage = new LoginPage()
                .successRegistratorLogin(validRegistrator);
            //
            // Check
            Assert.AreEqual(validRegistrator.GetLogin(), registratorHomePage.GetLoginNameText(),
                "Assert Error. Invalid User Login.");
            //
            // Steps
            LoginPage loginPage = registratorHomePage.Logout();
            //
            // Check
            Assert.True(loginPage.GetLogoPictureSrcAttributeText()
                .Contains(LoginPage.IMAGE_NAME), "Assert Error. LoginPage not Found.");
        }
    }
}
