using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class HomePageNonAuthorizedUser : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        public SignInSignUpHeaderButtons SignInSignUpHeaderButtons { get; }

        public HomePageNonAuthorizedUser(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            SignInSignUpHeaderButtons = new SignInSignUpHeaderButtons(driver);
        }
    }
}
