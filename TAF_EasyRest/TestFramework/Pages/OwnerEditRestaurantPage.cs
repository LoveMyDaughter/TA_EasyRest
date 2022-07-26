using TestFramework.PageComponents;
namespace TestFramework.Pages;

public class OwnerEditRestaurantPage : BasePage
{
    public OwnerEditRestaurantPage(IWebDriver driver) : base(driver)
    {
        ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
    }
    public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
    public NavigationMenuPageComponent NavigationMenuPageComponent { get; }

    private IWebElement _editRestaurantButton => driver.FindElement(By.XPath("//button[@title = 'Edit Information']"));
    private IWebElement _updateRestaurantButton => driver.FindElement(By.XPath("//span[contains(text(),'Update')]/parent::button"));
    private IWebElement _cancelEditRestaurantButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));

    public OwnerEditRestaurantPage ClickEditRestaurantButton()
    {
        _editRestaurantButton.Click();
        return this;
    }
    public OwnerEditRestaurantPage UpdateEditRestaurantButton()
    {
        _updateRestaurantButton.Click();
        return this;
    }
    public OwnerEditRestaurantPage CancelRestaurantButton()
    {
        _cancelEditRestaurantButton.Click();
        return this;
    }
}
