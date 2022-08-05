using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents.Owner.CreateMenuPageComponents;

namespace TestFramework.Pages.Owner
{
    public class CreateMenuPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        public CreateMenuPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        private IWebElement _menuNameField => driver.FindElement(By.Name("Menu Name"));
        private IWebElement _listMenuRaioButton => driver.FindElement(By.XPath("//span[text() = 'List menu']"));
        private IWebElement _imageMenuRaioButton => driver.FindElement(By.XPath("//span[text() = 'Image menu']"));
        private IWebElement _nextButton => driver.FindElement(By.XPath("//legend[contains(text(),'Choose menu type:')]/parent::div/parent::div/following-sibling::div[2]"));

        public CreateMenuPage ClickMenuNameField()
        {
            _menuNameField.Click();
            return this;
        }
        public CreateMenuPage SendKeysToMenuNameField(string name)
        {
            _menuNameField.SendKeys(name);
            return this;
        }
        public CreateMenuPage ClickListMenuRaioButton()
        {
            _listMenuRaioButton.Click();
            return this;
        }
        public CreateMenuPage ClickImageMenuRaioButton()
        {
            _imageMenuRaioButton.Click();
            return this;
        }
        public CreateListMenuComponent ClickNextButton()
        {
            _nextButton.Click();
            return new CreateListMenuComponent(driver);
        }
    }
}

