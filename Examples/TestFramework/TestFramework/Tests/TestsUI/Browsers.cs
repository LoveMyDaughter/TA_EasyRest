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
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Core;

namespace RvCrashCourse2021
{
    [AllureNUnit]
    [TestFixture]
    class Browsers
    {
        //Клас тестів  , що відображає можливості конфігурації різних браузерів

        [Test]
        public void Firefox1()
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Firefox2()
        {
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            //IWebDriver driver = new FirefoxDriver(profile); // Deprecated
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Firefox3()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.AcceptUntrustedCertificates = true;
            //profiles.AssumeUntrustedCertificateIssuer = true;
            //
            //profile.SetPreference("app.update.enabled", false);
            //profile.SetPreference("app.update.auto", false);
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

       // [Test]
       // Приклад запуску плагінів у Firefox
        public void Firefox4()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.AddExtension("C:\\selenium_ide.xpi");
            profile.SetPreference("extensions.firebug.currentVersion", "2.0.19");
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //
            driver.Quit();
        }

        [Test]
        public void Firefox5()
        {
            FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = "calc.exe";
            // Start application with a debugging console. Windows only.
            options.AddArgument("-console");
            // Runs Firefox in headless mode. Available in Firefox 56+
            options.AddArgument("-headless");
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Thread.Sleep(1000);
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("c:/ScreenshotGoogle0.png", ScreenshotImageFormat.Png);
            //
            driver.Quit();
        }

        //[Test]
        public void IE1()
        {
            IWebDriver driver = new InternetExplorerDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void IE2()
        {
            InternetExplorerOptions options = new InternetExplorerOptions()
            {
                //InitialBrowserUrl = baseURL,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false
            };
            IWebDriver driver = new InternetExplorerDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome1()
        {
            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome2()
        {   // Default Profile
            ChromeOptions options = new ChromeOptions();
            string homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            Console.WriteLine("homePath = " + homePath);
            string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data";
            //string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default"; // ERROR
            Console.WriteLine("userProfile = " + userProfile);
            options.AddArguments("--user-data-dir=" + userProfile);
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //driver.Quit();
        }

        //[Test]
        public void Chrome3()
        {   // Add Arguments
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome4()
        {   // Executable Location
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"C:\Users\yharasym\Downloads\VideoTAQC\ChromiumPortable\ChromiumPortable.exe";
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

       // [Test]
        public void Chrome5()
        {   // Headless
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            Console.WriteLine("Title0= " + driver.Title);
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Console.WriteLine("Title1= " + driver.Title);
            //driver.FindElement(By.Name("q")).SendKeys("Cheese");
            //driver.FindElement(By.Name("q")).Submit();
            //Thread.Sleep(2000);
            //
            //ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            //Screenshot screenshot = takesScreenshot.GetScreenshot();
            //screenshot.SaveAsFile("с:/ScreenshotGoogle1.png", ScreenshotImageFormat.Png);
            ////
            Console.WriteLine("Title2= " + driver.Title);
            driver.Quit();
        }

    }
}
