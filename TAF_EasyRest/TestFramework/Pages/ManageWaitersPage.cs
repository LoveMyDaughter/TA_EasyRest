using TestFramework.PageComponents;
namespace TestFramework.Pages
{
    public class ManageWaitersPage : BasePage
    {
        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
            ManageRestaurantPageComponent = new ManageRestaurantPageComponent(driver);
        }
        public ManageRestaurantPageComponent ManageRestaurantPageComponent { get; }

        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//button[@title = 'Add Waiter")); // change XPath
       

        public CreateNewWaiterPageComponent ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            return new CreateNewWaiterPageComponent(driver);
        }
       
    }
}
