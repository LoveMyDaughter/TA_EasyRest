using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class HomePageNonAuthorizedUserPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get; }
        public SignInSignUpHeaderButtonsPageComponent SignInSignUpHeaderButtons { get; }

        public HomePageNonAuthorizedUserPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            SignInSignUpHeaderButtons = new SignInSignUpHeaderButtonsPageComponent(driver);
        }
    }
}
