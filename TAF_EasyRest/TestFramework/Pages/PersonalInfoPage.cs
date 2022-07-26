using TestFramework.PageComponents;

namespace TestFramework.Pages
{
    public class PersonalInfoPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get;  }

        public PersonalInfoPage(IWebDriver driver) : base(driver) 
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        }
    }
}
