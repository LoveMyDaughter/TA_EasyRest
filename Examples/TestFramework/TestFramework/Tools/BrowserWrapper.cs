using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestFramework.Data.Application;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Opera;

namespace TestFramework.Tools
{
    public interface IBrowser
    {
        // Factory Method
        IWebDriver GetBrowser(ApplicationSource applicationSource);
    }

    public class FirefoxTemporaryWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            return new FirefoxDriver();
        }
    }

    public class ChromeTemporaryWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            return new ChromeDriver();
        }
    }

    public class ChromeTemporaryWithoutUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            // TODO foreach(BrowserOptions)
            //options.addArguments("--headless");
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            options.AddArguments("--headless");
            //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
            return new ChromeDriver(options);
        }
    }

    public class ChromeTemporaryMaximizedWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            // TODO foreach(BrowserOptions)
            //options.addArguments("--headless");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
            return new ChromeDriver(options);
        }
    }

    #region SelenoidBrowsers
    public class SelenoidChromeDriver : IBrowser
    {
        private const int CI_TIME_SPAN = 3;

        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            var runName = GetType().Assembly.GetName().Name;
            var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";

            var timespan = TimeSpan.FromMinutes(CI_TIME_SPAN);
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            options.AddArguments("--ignore-certificate-errors");
            options.AddAdditionalCapability("name", runName, true);
            options.AddAdditionalCapability("videoName", $"{runName}.{timestamp}.mp4", true);
            options.AddAdditionalCapability("logName", $"{runName}.{timestamp}.log", true);
            options.AddAdditionalCapability("enableVNC", true, true);
            options.AddAdditionalCapability("enableVideo", true, true);
            options.AddAdditionalCapability("enableLog", true, true);
            options.AddAdditionalCapability("screenResolution", "1920x1080x24", true);

            var _driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), options);

            return _driver;
        }
    }

    public class SelenoidFireFoxWebDriver : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            var runName = GetType().Assembly.GetName().Name;
            var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
            var firefoxoptions = new FirefoxOptions();
            firefoxoptions.AddArgument("start-maximized");
            firefoxoptions.AddAdditionalCapability("name", runName, true);
            firefoxoptions.AddAdditionalCapability("videoName", $"{runName}.{timestamp}.mp4", true);
            firefoxoptions.AddAdditionalCapability("logName", $"{runName}.{timestamp}.log", true);
            firefoxoptions.AddAdditionalCapability("enableVNC", true, true);
            firefoxoptions.AddAdditionalCapability("enableVideo", true, true);
            firefoxoptions.AddAdditionalCapability("enableLog", true, true);
            firefoxoptions.AddAdditionalCapability("screenResolution", "1920x1080x24", true);

            var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), firefoxoptions);

            return driver;
        }
    }

    public class SelenoidOperaWebDriver : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            var runName = GetType().Assembly.GetName().Name;
            var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";

            var firefoxoptions = new OperaOptions();
            firefoxoptions.AddArgument("start-maximized");
            firefoxoptions.AddAdditionalCapability("name", runName, true);
            firefoxoptions.AddAdditionalCapability("videoName", $"{runName}.{timestamp}.mp4", true);
            firefoxoptions.AddAdditionalCapability("logName", $"{runName}.{timestamp}.log", true);
            firefoxoptions.AddAdditionalCapability("enableVNC", true, true);
            firefoxoptions.AddAdditionalCapability("enableVideo", true, true);
            firefoxoptions.AddAdditionalCapability("enableLog", true, true);
            firefoxoptions.AddAdditionalCapability("screenResolution", "1920x1080x24", true);

            var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), firefoxoptions);

            return driver;
        }
    }

    #endregion


    public class BrowserWrapper
    {
        private const string TIME_TEMPLATE = "yyyy_MM_dd_HH_mm_ss";
        private const string SCREENSHOT_PNG = "_Screenshot.png";
        private const string SOURCECODE_TXT = "_SourceCode.txt";
        private const string STRING_TRUE = "true";
        private const string IS_CONTINUES_INTEGRATION = "IS_CONTINUES_INTEGRATION";
        private const string DEFAULT_BROWSER = "DefaultTemporary";
        private const string CONTINUES_INTEGRATION_BROWSER = ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI;
        //
        // Fields
        private Dictionary<string, IBrowser> Browsers;
        public IWebDriver Driver { get; private set; }

        public BrowserWrapper(ApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            // TODO Use Const
            Browsers = new Dictionary<string, IBrowser>();
            Browsers.Add(DEFAULT_BROWSER, new ChromeTemporaryWhithUI());
            Browsers.Add(ApplicationSourceRepository.FIREFOX_TEMPORARY_WHITH_UI, new FirefoxTemporaryWhithUI());
            Browsers.Add(ApplicationSourceRepository.CHROME_TEMPORARY_WHITH_UI, new ChromeTemporaryWhithUI());
            Browsers.Add(ApplicationSourceRepository.CHROME_TEMPORARY_MAXIMIZED_WHITH_UI, new ChromeTemporaryMaximizedWhithUI());
            Browsers.Add(ApplicationSourceRepository.SELENOID_CHROME, new SelenoidChromeDriver());
            Browsers.Add(ApplicationSourceRepository.SELENOID_FIREFOX, new SelenoidFireFoxWebDriver());
            Browsers.Add(ApplicationSourceRepository.SELENOID_OPERA, new SelenoidOperaWebDriver());
            Browsers.Add(CONTINUES_INTEGRATION_BROWSER, new ChromeTemporaryWithoutUI());
        }

        private void InitWebDriver(ApplicationSource applicationSource)
        {
            //MessageBox.Show("Running InitWebDriver() BrowserName = " + applicationSource.BrowserName ,
            //    "Run", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            IBrowser currentBrowser = Browsers[DEFAULT_BROWSER];
            
            if (IsContinuesIntegration())
            {
                currentBrowser = Browsers[CONTINUES_INTEGRATION_BROWSER];
                // TODO Remone Message
                Console.WriteLine("currentBrowser= Browsers[CONTINUES_INTEGRATION_BROWSER]");
            }
            else
            {
                foreach (KeyValuePair<string, IBrowser> current in Browsers)
                {
                    if (current.Key.ToString().ToLower()
                            .Equals(applicationSource.BrowserName.ToLower()))
                    {
                        currentBrowser = current.Value;
                        break;
                    }
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);

            // TODO Move to Search Class
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan
            //        .FromSeconds(applicationSource.ImplicitWaitTimeOut);
        }

        private bool IsContinuesIntegration()
        {
            // TODO Remone Message
            //MessageBox.Show("IS_CONTINUES_INTEGRATION = " + System.Environment.GetEnvironmentVariable(IS_CONTINUES_INTEGRATION),
            //    "CI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Console.WriteLine("+++ " + IS_CONTINUES_INTEGRATION + "= " 
            //        + System.Environment.GetEnvironmentVariable("IS_CONTINUES_INTEGRATION"));
            return System.Environment.GetEnvironmentVariable(IS_CONTINUES_INTEGRATION) == STRING_TRUE;
        }

        private string GetTime()
        {
            DateTime localDate = DateTime.Now;
            //return new DateTime().ToString("yyyyMMddHHmmssffff");
            //return new DateTime().ToStringlocalDate("yyyy_MM_dd_HH_mm_ss_ffff");
            //return localDate.ToString("yyyy_MM_dd_HH_mm_ss");
            return localDate.ToString(TIME_TEMPLATE);
        }

        private string GetCurrentDirectory()
        {
            //Console.WriteLine("Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase) = "
            //    + Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(6));
            //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase): "
            //    + Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase),
            //    "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            // TODO Create Const for 6
            //return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(6);
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase)
                    .Substring(AExternalReader.PATH_PREFIX);
        }

        public string SaveScreenshot()
        {
            return SaveScreenshot(null);
        }

        public string SaveScreenshot(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            //Console.WriteLine("namePrefix = " + namePrefix + "  Directory.GetCurrentDirectory() = " + Directory.GetCurrentDirectory());
            ITakesScreenshot takesScreenshot = Driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            //screenshot.SaveAsFile(namePrefix + "_Screenshot.png", ScreenshotImageFormat.Png);
            //screenshot.SaveAsFile(namePrefix + "_Screenshot.png");
            //screenshot.SaveAsFile(@"D:\Screenshot.png", ScreenshotImageFormat.Png);
            screenshot.SaveAsFile(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + SCREENSHOT_PNG, ScreenshotImageFormat.Png);
            return namePrefix;
        }

        public string SaveSourceCode()
        {
            return SaveSourceCode(null);
        }

        public string SaveSourceCode(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            //File.WriteAllText(namePrefix + "_SourceCode.txt", Driver.PageSource);
            //File.WriteAllText(@"D:\SourceCode.txt", Driver.PageSource);
            File.WriteAllText(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + SOURCECODE_TXT, Driver.PageSource);
            return namePrefix;
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

    }
}
