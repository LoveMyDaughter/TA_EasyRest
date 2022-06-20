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
using TestFramework.Data.Application;
using NUnit.Framework.Interfaces;
using NUnit.Allure.Attributes;
using NLog;
using System.IO;
using NUnit.Allure.Core;

namespace TestFramework.Tools
{
    [AllureNUnit]
    [TestFixture]
    public abstract class TestRunner
    {
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //
      //  protected readonly double DOUBLE_PRECISE = 0.01;
        //
        //protected bool isTestSuccess = false;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //Important for Allure!!!
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            

         //   Application.Get(ApplicationSourceRepository.SelenoidFirefox());
            Application.Get(ApplicationSourceRepository.SelenoidChrome());
           // Application.Get(ApplicationSourceRepository.ChromeTemporaryHeroku());
           // Application.Get(ApplicationSourceRepository.ChromeWithoutUIHeroku());
         //   Application.Get(); // Default
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            //Application.Get().LoadLoginPage();
            //isTestSuccess = false;
        }

        [TearDown]
        public void TearDown()
        {
            //if (!isTestSuccess)
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Application.Get().SaveCurrentState();
                log.Error("Test Failed");
            }
            // Logout
            Application.Get().LogoutAction();
        }

        protected LoginPage StartApplication()
        {
            return Application.Get().LoadLoginPage();
        }

        public static T GetPage<T>(string url) where T : ATopComponent
        {
            log.Info($"Open page {typeof(T)}");

            Application.Get().Browser.OpenUrl(url);

            return Activator.CreateInstance<T>();
        }
    }
}
