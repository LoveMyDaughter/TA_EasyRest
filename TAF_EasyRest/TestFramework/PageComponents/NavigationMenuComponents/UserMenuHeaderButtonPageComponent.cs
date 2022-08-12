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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            var el = wait.Until(ExpectedConditions.ElementIsVisible(_userMenu));
            el.Click();
            return new UserMenuDropDownListPageComponent(driver);
        }

        //cutty variant of the method above, same function
        public UserMenuDropDownListPageComponent ClickUserMenuButton2(int timeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementIsVisible(_userMenu))
                .Click();
            return new UserMenuDropDownListPageComponent(driver);
        }

        public UserMenuDropDownListPageComponent ClickUserMenuButton3(int timeToWait)
        {
            WaitUntilElementIsVisible(_userMenu, driver, timeToWait)
                .Click();
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
