using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;
namespace TestFramework.Pages
{
    public class ManageAdministratorPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
        public ManageAdministratorPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);         
        }
        
        private IWebElement _addAdministratorButton => driver.FindElement(By.XPath("//button[@title = 'Add Administrator"));

       public CreateNewAdministratorPageComponent ClickAddAdministratorButton()
        {
            _addAdministratorButton.Click();
            return new CreateNewAdministratorPageComponent(driver);
        }

    }
}
