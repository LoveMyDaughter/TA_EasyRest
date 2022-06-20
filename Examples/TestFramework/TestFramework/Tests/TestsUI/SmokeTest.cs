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
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class SmokeTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ValidUsers =
        {
            //new object[] { UserRepository.Get().Registered() },
            new object[] { UserRepository.Get().Registered() }
        };

        // DataProvider
        private static readonly object[] ExternalValidUsers =
            //ListUtils.ToMultiArray(UserRepository.Get().FromCsv());
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        [Test, TestCaseSource(nameof(ValidUsers))]
        ////[Test, TestCaseSource("ValidUsers")]
        [Category("Smoke")]
      //  [Test, TestCaseSource("ExternalValidUsers")]
        public void LoginTest9(IUser validRegistrator)
        {
            //Console.WriteLine("ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            log.Info("Test Start: ThreadID= " + Thread.CurrentThread.ManagedThreadId);


            var loginPage1 = GetPage<LoginPage>("http:\\127.0.0.1\\");

            // Steps
            RegistratorHomePage registratorHomePage = StartApplication()
                .successRegistratorLogin(validRegistrator);
          
            // Check
            log.Info("Check Invalid User Login");
            Assert.AreEqual(validRegistrator.GetLogin(), registratorHomePage.GetLoginNameText(),
                "Assert Error. Invalid User Login.");
            //
            //int k = 1;
            //if (k > 0)
            //{
            //    throw new Exception("Will be Failed");
            //}
            //
            // Steps
            LoginPage loginPage = registratorHomePage.Logout();
            //
            // Check
            Assert.True(loginPage.GetLogoPictureSrcAttributeText()
                .Contains(LoginPage.IMAGE_NAME), "Assert Error. LoginPage not Found.");
            //    .Contains(LoginPage.IMAGE_NAME+"1"), "Assert Error. LoginPage not Found.");
            //
            //isTestSuccess = true;
            //throw new Exception("Will be Failed");
            log.Info("Test Done: ThreadID= " + Thread.CurrentThread.ManagedThreadId);
        }

        // DataProvider
        private static readonly object[] LocalizationData =
        {
            new object[] { ChangeLanguageFields.ENGLISH },
            new object[] { ChangeLanguageFields.RUSSIAN },
            new object[] { ChangeLanguageFields.UKRAINIAN }
        };

        [Category("Smoke")]
        [Test, TestCaseSource("LocalizationData")]
        public void LocalizationTest1(ChangeLanguageFields languageFields)
        {
            //
            // Steps
            LoginPage loginPage = StartApplication()
                    .ChangeLanguage(languageFields);

            //
            Thread.Sleep(2000);
            //
            // Check
            Assert.AreEqual(LoginPageL10nRepository.LoginPageLanguages[LoginPageL10nFields.LOGIN_LABEL][languageFields],
                loginPage.GetLoginLabelText(), "Assert Error. Invalid Localization LoginLabel.");
            //
            Assert.AreEqual(LoginPageL10nRepository.LoginPageLanguages[LoginPageL10nFields.PASSWORD_LABEL][languageFields],
                loginPage.GetPasswordLabelText(), "Assert Error. Invalid Localization PasswordLabel.");
            //
            Assert.AreEqual(LoginPageL10nRepository.LoginPageLanguages[LoginPageL10nFields.SIGNIN_BUTTON][languageFields],
                loginPage.GetSigninButtonText(), "Assert Error. Invalid Localization SigninButton.");
        }

    }
}
