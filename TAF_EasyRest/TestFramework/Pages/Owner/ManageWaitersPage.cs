using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;

namespace TestFramework.Pages
{
    public class ManageWaitersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
        
        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }

        private IList<IWebElement> _items => _waitersParent.FindElements(By.XPath("//li/child::button"));
        private IWebElement _waitersParent => driver.FindElement(By.XPath("//li/parent::ul/parent::div"));
        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//button[@title = 'Add Waiter"));
        public ManageWaitersPage ClickFirstWaiterRemoveButton()
        {
            var firstWaiterRemoveButton = _items.ElementAt(0);
            firstWaiterRemoveButton.Click();

            return new ManageWaitersPage(driver);
        }
        public CreateNewWaiterPageComponent ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            return new CreateNewWaiterPageComponent(driver);
        }
       
    }
}
