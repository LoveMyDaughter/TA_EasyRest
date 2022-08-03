using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

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

        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//button[@title = 'Add Waiter")); 
       
        public CreateNewWaiterPageComponent ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            return new CreateNewWaiterPageComponent(driver);
        }
       
    }
}
