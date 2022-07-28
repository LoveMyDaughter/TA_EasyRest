using TestFramework.PageComponents;
namespace TestFramework.Pages;
public class OwnerPanelRestaurantsPage : BasePage
{

    public PersonalInfoPageComponent PersonalInfoPageComponent { get; }

    public OwnerPanelRestaurantsPage(IWebDriver driver) : base(driver)
    {
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