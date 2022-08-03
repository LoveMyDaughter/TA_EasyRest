using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages;
public class OwnerPanelRestaurantsPage : BasePage
{

    public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
    public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
    public OwnerPanelRestaurantsPage(IWebDriver driver) : base(driver)
    {
        NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);      
    }

    private IWebElement _threeDotButton => driver.FindElement(By.XPath("//span[text() != 'ARCHIVED']/ancestor::div/button"));
    private IWebElement _addRestaurantButton => driver.FindElement(By.XPath("//button[@title = 'Add restaurant']"));

    public OwnerPanelPageComponent ClickThreeDotButton()
    {
        _threeDotButton.Click();
        return new OwnerPanelPageComponent(driver);
    }

    public OwnerPanelRestaurantsPage ClickAddRestaurantButton()
    {
        _addRestaurantButton.Click();
        return this;
    }




}