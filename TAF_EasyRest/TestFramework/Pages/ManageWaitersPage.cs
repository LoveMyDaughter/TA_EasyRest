using TestFramework.PageComponents;
namespace TestFramework.Pages
{
    public class ManageWaitersPage : BasePage
    {
        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
            personalInfoPageComponent = new ManageWa(driver);
        }
        public ManageWa personalInfoPageComponent { get; }

        private IWebElement _removeWaiterButton(string username) => driver.FindElement(By.XPath($"//span[contains(text(), '{username}')]/parent::div//following-sibling::button"));
        private IWebElement _addWaiterButton => driver.FindElement(By.XPath("//*[@id='root']/div/main/div[2]/button")); // change XPath
       

        public CreateNewWaiterPageComponent ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            return new CreateNewWaiterPageComponent(driver);
        }
       
    }
}
