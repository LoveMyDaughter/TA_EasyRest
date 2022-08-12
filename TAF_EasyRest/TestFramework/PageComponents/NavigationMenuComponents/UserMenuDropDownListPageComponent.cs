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
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementIsVisible(_myProfile))
                .Click();
        }

        public void ClickLogOutButton(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementIsVisible(_logOut))
                .Click();
        }
    }
}
