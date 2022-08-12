namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuHeaderButtonPageComponent
    {
        IWebDriver driver { get; }

        public UserMenuHeaderButtonPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _userMenu => driver.FindElement(By.XPath("//div[contains(@class, 'UserMenu-avatar')]"));

        public UserMenuDropDownListPageComponent ClickUserMenuButton()
        {
            _userMenu.Click();
            Thread.Sleep(1000);
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
