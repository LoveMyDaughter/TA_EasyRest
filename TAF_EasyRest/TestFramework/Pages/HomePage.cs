using TestFramework.PagesComponents;

namespace TestFramework.Pages
{
    internal class HomePage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }
    }
}
