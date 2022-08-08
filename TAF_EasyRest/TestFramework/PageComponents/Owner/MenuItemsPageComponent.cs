namespace TestFramework.PageComponents.Owner
{
    public class MenuItemsPageComponent
    {
        private IWebDriver driver;
        public MenuItemsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> _itemsList => driver.FindElements(By.XPath("//tr[contains(@class,'MuiTableRow-root-209 MuiTableRow-hover-211 MenuTable-tableRow-178 MenuTable-tableRowHover-180')]"));

        public MenuItemsPageComponent DeleteItem()
        {
            var FirstItemFormList = _itemsList.ElementAt(0);
            var DeleteButton = FirstItemFormList.FindElement(By.XPath("(.//button)[1]"));
            DeleteButton.Click();

            return new MenuItemsPageComponent(driver);
        }
    }
}
