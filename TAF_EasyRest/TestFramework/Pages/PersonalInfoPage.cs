using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class PersonalInfoPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageWa PersonalInfoPageComponent { get;  }

        public PersonalInfoPage(IWebDriver driver) : base(driver) 
        {
            PersonalInfoPageComponent = new ManageWa(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        }
    }
}
