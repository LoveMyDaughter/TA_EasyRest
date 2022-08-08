using TestFramework.PageComponents.Owner;

namespace TestFramework.Pages
{
    public class MenuItemsPage :BasePage
    {
        private IWebDriver driver;

        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        public MenuItemsPage(IWebDriver driver): base(driver)
        {
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }

        private IReadOnlyCollection<IWebElement> _itemsList => driver.FindElements(By.XPath("//tr[contains(@class,'MuiTableRow-root-209 MuiTableRow-hover-211 MenuTable-tableRow-178 MenuTable-tableRowHover-180')]"));
        private IWebElement _changeItem => _itemsList.ElementAt(0).FindElement(By.XPath(".//button[2]"));

        public MenuItemsPage DeleteItem()
        {
            var FirstItemFormList = _itemsList.ElementAt(0);
            var DeleteButton = FirstItemFormList.FindElement(By.XPath("(.//button)[1]"));
            DeleteButton.Click();

            return new MenuItemsPage(driver);
        }

        public ChangeItemMenuPageComponent ChangeItem()
        {
            _changeItem.Click();
            return new ChangeItemMenuPageComponent(driver); 
        }

    }
}
