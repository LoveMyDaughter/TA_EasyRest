namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuDropDownListPageComponent : BasePageComponent
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
            WaitUntilElementIsVisible(_myProfile, driver, timeToWait)
                .Click();
        }

        public void ClickLogOutButton(int timeToWait)
        {
            WaitUntilElementIsVisible(_logOut, driver, timeToWait)
                .Click();
        }
    }
}
