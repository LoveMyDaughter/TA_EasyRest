using TestFramework.PageComponents;

namespace TestFramework.Pages
{
    internal class HomePage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }
    }
}
