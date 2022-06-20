using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Data.Application
{
    public class ApplicationSource
    {
        // Browser Data
        public string BrowserName { get; private set; }
        //public string DriverPath { get; private set; }
        //public string BrowserPath { get; private set; }
        //public string DefaulProfile { get; private set; }
        //public IList<string> BrowserOptions { get; private set; }

        // Implicit and Explicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        //public long ImplicitLoadTimeOut { get; private set; }
        //public long ImplicitScriptTimeOut { get; private set; }
        public long ExplicitTimeOut { get; private set; }

        // Localization Strategy
        // public string Language { get; private set; }

        // Search Strategy
        //public string SearchStrategy { get; private set; }

        // Logger Strategy
        // public string LoggerStrategy { get; private set; }

        // Reporter Console Output
        //public boolean ConsoleOutput { get; private set; }

        // URLs
        //public string BaseUrl { get; private set; }
        public string LoginUrl { get; private set; }
        public string LogoutUrl { get; private set; }
        //public string AdminLoginUrl { get; private set; }
        //public string AdminLogoutUrl { get; private set; }

        //Database Connection
        public string DatabaseUrl { get; private set; }
        public string DatabaseLogin { get; private set; }
        public string DatabasePassword { get; private set; }

        // TODO Develop Builder
        public ApplicationSource(string browserName,
                                 long implicitWaitTimeOut, long explicitTimeOut,
                                 string loginUrl, string logoutUrl)
        {
            this.BrowserName = browserName;
            this.ImplicitWaitTimeOut = implicitWaitTimeOut;
            this.ExplicitTimeOut = explicitTimeOut;
            this.LoginUrl = loginUrl;
            this.LogoutUrl = logoutUrl;
        }
    }
}
