namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuHeaderButtonPageComponent : BasePageComponent
    {
        IWebDriver driver { get; }

        public UserMenuHeaderButtonPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By _userMenu = By.XPath("//div[contains(@class, 'UserMenu-avatar')]");

        public UserMenuDropDownListPageComponent ClickUserMenuButton(int timeToWait)
        {
            WaitUntilElementIsVisible(_userMenu, driver, timeToWait)
                .Click();
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
