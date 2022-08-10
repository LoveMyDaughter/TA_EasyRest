using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;

namespace TestFramework.Pages;

public class OwnerEditRestaurantPage : BasePage
{

    public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
    public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
    public NewRestaurantPageComponet NewRestaurantPageComponet { get; }
    public UserMenuHeaderButtonPageComponent UserMenuHeaderButtonPageComponent { get; }

    public OwnerEditRestaurantPage(IWebDriver driver) : base(driver)
    {
        NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        NewRestaurantPageComponet = new NewRestaurantPageComponet(driver);
        UserMenuHeaderButtonPageComponent = new UserMenuHeaderButtonPageComponent(driver);
    }

    private IWebElement _editInformationButton => driver.FindElement(By.XPath("//button[@title = 'Edit Information']"));

    public OwnerEditRestaurantPageComponent ClickEditRestaurantButton()
    {
        _editInformationButton.Click();
        return new OwnerEditRestaurantPageComponent(driver);
    }
   
}
