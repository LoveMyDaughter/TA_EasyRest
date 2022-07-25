
namespace TestFramework.PagesComponents
{
    public class NavigationMenuPageComponent : BasePage
    {
        public NavigationMenuPageComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, timeout);
        }

        protected static TimeSpan timeout = TimeSpan.FromSeconds(10);
        protected static WebDriverWait wait;

        private IWebElement _HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement _RestaurantsList => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        private IWebElement _SignIn => driver.FindElement(By.XPath("//span[text()='Sign In']"));
        private IWebElement _SignUp => driver.FindElement(By.XPath("//span[text()='Sign Up']"));

        private IWebElement _UserMenu = wait.Until(drv => drv.FindElement(By.XPath("//button/span/div")));
        private IWebElement _MyProfile = wait.Until(drv => drv.FindElement(By.XPath("//a[@role='menuitem']")));
        private IWebElement _LogOut = wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Log Out']")));


        public NavigationMenuPageComponent ClickHomeButton()
        {
            _HomeButton.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickRestaurantsListButton()
        {
            _RestaurantsList.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickSignInButton()
        {
            _SignIn.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickSignUpButton()
        {
            _SignUp.Click();
            return this;
        }

        public NavigationMenuPageComponent NavigateToMyProfile()
        {
            _UserMenu.Click();
            _MyProfile.Click();
            return this;
        }

        public NavigationMenuPageComponent LogOut()
        {
            _UserMenu.Click();
            _LogOut.Click();
            return this;
        }




    }
}
