namespace TestFramework.PageComponents.Owner
{
    public class CommonMenuItemsPageComponent
    {
        private IWebDriver driver;
        public CommonMenuItemsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> _itemsList => driver.FindElements(By.XPath("//tr[contains(@class,'MuiTableRow-root-209 MuiTableRow-hover-211 MenuTable-tableRow-178 MenuTable-tableRowHover-180')]"));

        public CommonMenuItemsPageComponent DeleteItem()
        {
            var FirstItemFormList = _itemsList.ElementAt(0);
            var DeleteButton = FirstItemFormList.FindElement(By.XPath("(.//button)[1]"));
            DeleteButton.Click();

            return new CommonMenuItemsPageComponent(driver);
        }
    }
}
