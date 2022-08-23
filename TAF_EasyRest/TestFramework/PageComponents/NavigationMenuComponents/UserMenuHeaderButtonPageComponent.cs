namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuHeaderButtonPageComponent 
    {
        IWebDriver driver { get; }

        public UserMenuHeaderButtonPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By _userMenu = By.XPath("//div[contains(@class, 'UserMenu-avatar')]");

        public UserMenuDropDownListPageComponent ClickUserMenuButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_userMenu, timeToWait)
                .Click();
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
