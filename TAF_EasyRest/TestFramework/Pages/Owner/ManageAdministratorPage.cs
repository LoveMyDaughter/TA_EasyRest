using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;
using TestFramework.Tools;

namespace TestFramework.Pages
{
    public class ManageAdministratorPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        public AdministratorItemPageComponent? AdministratorItem
        {
            get
            {
                var element = driver.FindElementSafe(By.XPath("//div/ul/li"));
                if (element != null)
                {
                    return new AdministratorItemPageComponent(element);
                } 
                else
                { 
                    return null; 
                }
            }
        }
        public ManageAdministratorPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        
        private IWebElement _addAdministratorButton => driver.FindElement(By.XPath("//button[@title = 'Add Administrator']"));

       public CreateNewAdministratorPageComponent ClickAddAdministratorButton(int timeToWait)
        {
            _addAdministratorButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(" //h6[contains(text(), 'Create New Administrator')]/parent::span/parent::div/parent::div/parent::div")));
            return new CreateNewAdministratorPageComponent(driver);
        }

    }
}
