using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages.Owner
{
    internal class CreateMenuPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        public CreateMenuPage(IWebDriver driver) : base(driver)
        {
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        private IWebElement _menuNameField => driver.FindElement(By.Name("Menu Name"));
        private IWebElement _listMenuButton => driver.FindElement(By.XPath("//span[text() = 'List menu']"));
        private IWebElement _imageMenuButton => driver.FindElement(By.XPath("//span[text() = 'List menu']"));
        private IWebElement _nextButton => driver.FindElement(By.XPath(" //span[text() = 'Next']"));

        public CreateMenuPage ClickMenuField()
        {
            _menuNameField.Click();
            return this;
        }
        public CreateMenuPage ClickListMenuButton()
        {
            _listMenuButton.Click();
            return this;
        }
        public CreateMenuPage ClickImageMenuButton()
        {
            _imageMenuButton.Click();
            return this;
        }
        public CreateMenuPage ClickNextButton()
        {
            _nextButton.Click();
            return this;
        }
    }
}

