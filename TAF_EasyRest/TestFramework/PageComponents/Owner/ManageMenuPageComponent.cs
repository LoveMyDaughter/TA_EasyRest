namespace TestFramework.PageComponents.Owner
{
    public class ManageMenuesPageComponent
    {
        private IWebDriver driver;
        private IList<IWebElement> _items => _menuParent.FindElements(By.XPath(".//a[contains(@class,'MuiButtonBase-root')and contains(@class,'MuiListItem-root')]"));
        public ManageMenuesPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _menuParent => driver.FindElement(By.XPath("//div[contains(@class,'MuiCollapse-container-')]"));
        private IWebElement _createMenu => driver.FindElement(By.XPath("//span[text()='Create menu']//ancestor::a"));

        public MenuItemsPageComponent ClickFirstMenu()
        {
            var firstMenu = _items.ElementAt(0);
            firstMenu.Click();

            return new MenuItemsPageComponent(driver);
        }
    }
}
