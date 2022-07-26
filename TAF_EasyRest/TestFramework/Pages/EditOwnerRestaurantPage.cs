using TestFramework.PageComponents;
namespace TestFramework.Pages;

public class OwnerEditRestaurantPage : BasePage
{
    public OwnerEditRestaurantPage(IWebDriver driver) : base(driver)
    {
        ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
    }
    public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

    private IWebElement _editRestaurantButton => driver.FindElement(By.XPath("//*[@id='root']/div/main/div[2]/button"));
    private IWebElement _updateRestaurantButton => driver.FindElement(By.XPath("//span[contains(text(),'Update')]/parent::button"));
    private IWebElement _cancelEditRestaurantButton => driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]/parent::button"));

    public ManageRestaurantPage ClickEditRestaurantButton()
    {
        _editRestaurantButton.Click();
        return this;
    }
    public ManageRestaurantPage UpdateEditRestaurantButton()
    {
        _updateRestaurantButton.Click();
        return this;
    }
    public ManageRestaurantPage CancelRestaurantButton()
    {
        _cancelEditRestaurantButton.Click();
        return this;
    }
}
