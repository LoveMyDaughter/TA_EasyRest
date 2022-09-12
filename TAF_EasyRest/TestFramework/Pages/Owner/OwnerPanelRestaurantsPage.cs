using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;

namespace TestFramework.Pages;
public class OwnerPanelRestaurantsPage : BasePage
{
    private static string _pageUrl = "/profile/restaurants/";

    public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
    public PersonalInfoPageComponent PersonalInfoPageComponent { get; }
    public List<RestaurantItemPageComponent> RestaurantItems {
        get {
            return driver.FindElements(By.XPath("//*[@id=\"root\"]/main/div/div/div/div[1]/div[1]/div"))
                .Select(e => new RestaurantItemPageComponent(e, driver)).ToList();
        }
    }
    public OwnerPanelRestaurantsPage(IWebDriver driver) : base(driver)
    {
        NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
    }

    private IWebElement _addRestaurantButton => driver.FindElement(By.XPath("//button[@title = 'Add restaurant']"));

    public OwnerPanelRestaurantsPage ClickAddRestaurantButton()
    {
        _addRestaurantButton.Click();
        return this;
    }

    public override void GoToUrl()
    {
        driver.Navigate().GoToUrl(baseUrl + _pageUrl);
    }
    public void WaitUntilRestaurantsLoaded(int timeToWait) 
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
        wait.Until(d => RestaurantItems.Count > 0);
    }
}