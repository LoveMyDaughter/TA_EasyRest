using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        public const string FIREFOX_TEMPORARY_WHITH_UI = "FirefoxTemporaryWhithUI";
        public const string CHROME_TEMPORARY_WHITH_UI = "ChromeTemporaryWhithUI";
        public const string CHROME_TEMPORARY_MAXIMIZED_WHITH_UI = "ChromeTemporaryMaximizedWhithUI";
        public const string CHROME_TEMPORARY_WITHOUT_UI = "ChromeTemporaryWithoutUI";
        public const string SELENOID_CHROME = "SelenoidChrome";
        public const string SELENOID_FIREFOX = "SelenoidFirefox";
        public const string SELENOID_OPERA = "SelenoidOpera";

        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeTemporaryHeroku();
        }

        public static ApplicationSource FirefoxTemporaryHeroku()
        {
            return new ApplicationSource(FIREFOX_TEMPORARY_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeTemporaryHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeMaximizedHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_MAXIMIZED_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeWithoutUIHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }
        
        public static ApplicationSource SelenoidChrome()
        {
            return new ApplicationSource(SELENOID_CHROME, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }
        
        public static ApplicationSource SelenoidFirefox()
        {
            return new ApplicationSource(SELENOID_FIREFOX, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }        
        
        public static ApplicationSource OpencartSelenoidFirefox()
        {
            return new ApplicationSource(SELENOID_FIREFOX, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }
    }
}