namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuHeaderButtonPageComponent
    {
        IWebDriver driver { get; set; }

        public UserMenuHeaderButtonPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _userMenu => driver.FindElement(By.XPath("//button/span[@class='MuiIconButton-label-2477']/div"));

        public UserMenuDropDownListPageComponent ClickUserMenuButton()
        {
            _userMenu.Click();
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
