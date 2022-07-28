using TestFramework.PageComponents;
namespace TestFramework.Pages
{
    public class ManageAdministratorPage : BasePage
    {
        public ManageAdministratorPage(IWebDriver driver) : base(driver)
        {
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        private IWebElement _addAdministratorButton => driver.FindElement(By.XPath("//button[@title = 'Add Administrator"));


        public CreateNewAdministratorPageComponent ClickAddAdministratorButton()
        {
            _addAdministratorButton.Click();
            return new CreateNewAdministratorPageComponent(driver);
        }

    }
}
