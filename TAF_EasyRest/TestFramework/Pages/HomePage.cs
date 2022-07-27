using TestFramework.PageComponents;

namespace TestFramework.Pages
{
    public class HomePage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }
    }
}
