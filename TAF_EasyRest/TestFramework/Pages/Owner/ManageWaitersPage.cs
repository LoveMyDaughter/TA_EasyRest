using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner;
using TestFramework.Tools;

namespace TestFramework.Pages
{
    public class ManageWaitersPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }
        public UserMenuHeaderButtonPageComponent UserMenuHeaderButtonPageComponent { get; }

        public List<WaiterItemPageComponent> WaiterItems => _items.Select(i => new WaiterItemPageComponent(i)).ToList();

        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
            UserMenuHeaderButtonPageComponent = new UserMenuHeaderButtonPageComponent(driver);
        }

        private IWebElement? _waitersParent => driver.FindElementSafe(By.XPath("//li/parent::ul/parent::div"));
        private IList<IWebElement> _items => _waitersParent?.FindElements(By.XPath("//li")).ToList() ?? new List<IWebElement>();
        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//button[@title = 'Add Waiter']"));

        public CreateNewWaiterPageComponent ClickAddWaiterButton(int timeToWait)
        {
            _addWaiterButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'phone_number']")));
            return new CreateNewWaiterPageComponent(driver);
        }
        public void WaitUntilWaitersLoaded(int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(d => _items.Count > 0);
        }      
    }
}
