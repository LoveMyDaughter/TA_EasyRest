using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents;

namespace TestFramework.Pages 
{
    public class NewRestaurantPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get;}
        public PersonalInfoPage PersonalInfo { get;}
        private static string _pageUrl => GetUrls.getUrl("NewRestaurantPage").Url;

        public NewRestaurantPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
            PersonalInfo = new PersonalInfoPage(driver);
        }

        private By _addButton => By.XPath("//button[@title='Add restaurant']");
        
        public NewRestaurantPageComponet ClickAddButton(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_addButton, timeToWait)
                .Click();
        
            return new NewRestaurantPageComponet(driver);
        }

        public override void GoToUrl()
        {
            driver.Navigate().GoToUrl(baseUrl + _pageUrl);
        }
    }
}
