using TestFramework.PagesComponents;

namespace TestFramework.Pages
{
    public class AdminPanelModeratorsPage : BasePage
    {

        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public AdminPanelPageComponent AdminPanelPageComponent { get; }


        private IWebElement _addModeratorButton => driver.FindElement(By.XPath("//*[@id = 'root']/div/main/a"));

        // Corresponding entry button. It's better to find 1-st row instead of certain user name. Like //tbody/tr[1]
        private IWebElement _padlockButton => driver.FindElement(By.XPath("//th[text()='Peter Moderator']/following-sibling::td/button"));
        private IWebElement _statusRecord => driver.FindElement(By.XPath("//th[text()='Peter Moderator']/following-sibling::td/p"));
        private IWebElement _padlockButtonForCertainUser(string username) => driver.FindElement(By.XPath($"//th[text()='{username}']/following-sibling::td/button"));



        public AdminPanelModeratorsPage(IWebDriver driver) : base(driver)
        {
            AdminPanelPageComponent = new AdminPanelPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        }

        public AdminPanelModeratorsPage ClickPadlockButton()
        {
            _padlockButton.Click();
            return this;
        }

        public AdminPanelModeratorsPage ClickAddModeratorButton()
        {
            _addModeratorButton.Click();
            return this;
        }

        public string StatusRecordGetText()
        {
            return _statusRecord.Text;
        }


    }
}