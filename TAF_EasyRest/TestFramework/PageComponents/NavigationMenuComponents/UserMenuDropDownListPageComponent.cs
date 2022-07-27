namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuDropDownListPageComponent
    {
        protected IWebDriver driver { get; set; }
        protected static TimeSpan timeout = TimeSpan.FromSeconds(3);
        protected static WebDriverWait wait { get; set; }


        public UserMenuDropDownListPageComponent(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, timeout);
            this.driver = driver;
        }

        private IWebElement _myProfile = wait.Until(drv => drv.FindElement(By.XPath("//a[@role='menuitem']")));
        private IWebElement _logOut = wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Log Out']")));

        public void ClickGoToMyProfileButton()
        {
            _myProfile.Click();
        }

        public void ClickLogOutButton()
        {
            _logOut.Click();
        }
    }
}
