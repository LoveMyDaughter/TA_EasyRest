using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestFramework.Data.Application;
using TestFramework.Pages;
using TestFramework.Tools.Find;

namespace TestFramework.Tools
{
    public class Application
    {
        private volatile static Application instance;
        private static object lockingObject = new object();
        //private static Logger log = LogManager.GetCurrentClassLogger();
        
        // TODO Change for parallel work
        public ApplicationSource ApplicationSource { get; private set; }
        //public FlexAssert FlexAssert { get; private set; }
        //
        //public BrowserWrapper Browser { get; private set; }
        
        // Parallel work
        private Dictionary<int, BrowserWrapper> browser;
        
        public BrowserWrapper Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                //if (browser[currentThread] == null)
                //browser.TryGetValue(key, out value);
                if (!browser.ContainsKey(currentThread))
                {
                    InitBrowser(currentThread);
                }
                return browser[currentThread];
            }
        }

        //private ISearch search;
        private ISearchStrategy search;
        //public ISearch Search
        public ISearchStrategy Search
        {
            get
            { if (search == null)
                {
                    InitSearch();
                }
                return search;
            }
            private set
            {
                search = value;
            }
        }
        public DBConnectionWrapper dbConnection { get; private set; }

        private Application(ApplicationSource applicationSource)
        {
            browser = new Dictionary<int, BrowserWrapper>();
            this.ApplicationSource = applicationSource;
        }

        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        if (applicationSource == null)
                        {
                            applicationSource = ApplicationSourceRepository.Default();
                        }
                        instance = new Application(applicationSource);
                        
                        //instance.InitBrowser(applicationSource);
                        //instance.InitSearch();
                    }
                }
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                foreach (KeyValuePair<int, BrowserWrapper> kvp in instance.browser)
                {
                    kvp.Value.Quit();
                }
                //
                // Change for parallel work
                // instance.Browser.Quit();
                //
                // Close DBConnection, etc.
                instance = null;
            }
        }

        //private void InitBrowser(ApplicationSource applicationSource)
        private void InitBrowser(int currentThread)
        {
            //this.Browser = new BrowserWrapper(applicationSource);
            browser.Add(currentThread, new BrowserWrapper(ApplicationSource));
        }

        private void InitSearch()
        {
            this.Search = new SearchElement();
        }

        public LoginPage LoadLoginPage()
        {
            //log.Debug("Start LoadLoginPage()");
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            //return new LoginPage(Browser.Driver);
            return new LoginPage();
        }

        //public LogoutPage LogoutAction()
        public LoginPage LogoutAction()
        //public void LogoutAction()
        {
            Browser.OpenUrl(ApplicationSource.LogoutUrl);
            //return new LoginPage(Browser.Driver);
            return new LoginPage();
        }

        public void SaveCurrentState()
        {
            //log.Warn("Saved Current State");
            string prefix = Browser.SaveScreenshot();
            Browser.SaveSourceCode(prefix);
        }

    }

}
