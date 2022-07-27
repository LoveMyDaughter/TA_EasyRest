namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuDropDownListPageComponent
    {
        protected IWebDriver driver { get; }

        public UserMenuDropDownListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _myProfile => driver.FindElement(By.XPath("//a[@role='menuitem']"));
        private IWebElement _logOut => driver.FindElement(By.XPath("//li[text()='Log Out']"));

        public void ClickMyProfileButton()
        {
            _myProfile.Click();
        }

        public void ClickLogOutButton()
        {
            _logOut.Click();
        }
    }
}
