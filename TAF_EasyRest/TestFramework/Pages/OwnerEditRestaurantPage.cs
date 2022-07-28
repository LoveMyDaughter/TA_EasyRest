using TestFramework.PageComponents;
namespace TestFramework.Pages;

public class OwnerEditRestaurantPage : BasePage
{
    public OwnerEditRestaurantPage(IWebDriver driver) : base(driver)
    {
        ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);       
    }
    public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
    
    private IWebElement _editInformationButton => driver.FindElement(By.XPath("//button[@title = 'Edit Information']"));


    public OwnerEditRestaurantPageComponent ClickEditRestaurantButton()
    {
        _editInformationButton.Click();
        return new OwnerEditRestaurantPageComponent(driver);
    }
   
}
