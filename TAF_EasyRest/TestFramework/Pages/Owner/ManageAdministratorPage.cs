using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;
using TestFramework.Tools;

namespace TestFramework.Pages
{
    public class ManageAdministratorPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        public AdministratorItemPageComponent? AdministratorItem
        {
            get
            {
                var element = driver.FindElementSafe(By.XPath("//div/ul/li"));
                if (element != null)
                {
                    return new AdministratorItemPageComponent(element);
                } else { return null; }
            }
        }
        public ManageAdministratorPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        
        private IWebElement _addAdministratorButton => driver.FindElement(By.XPath("//button[@title = 'Add Administrator']"));

       public CreateNewAdministratorPageComponent ClickAddAdministratorButton()
        {
            _addAdministratorButton.Click();
            Thread.Sleep(3000); //change to waiter
            return new CreateNewAdministratorPageComponent(driver);
        }

    }
}
