namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuDropDownListPageComponent 
    {
        IWebDriver driver { get; }

        public UserMenuDropDownListPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By _myProfile = By.XPath("//a[@role='menuitem']");
        private By _logOut = By.XPath("//li[text()='Log Out']");

        public void ClickMyProfileButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_myProfile, timeToWait)
                .Click();
        }

        public void ClickLogOutButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_logOut, timeToWait)
                .Click();
        }
    }
}
