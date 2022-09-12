
namespace TestFramework.PageComponents.Owner
{
    public class ManageRestaurantPageComponent : BasePage
    {
        public ManageRestaurantPageComponent(IWebDriver driver) : base(driver) { }

        protected IWebElement _detailsButton => driver.FindElement(By.XPath("//span[contains(text(), 'Details')]/parent::div/parent::a"));
        protected IWebElement _menuesButton => driver.FindElement(By.XPath("//span[contains(text(), 'Menues')]/parent::div/parent::div"));
        protected IWebElement _waitersButton => driver.FindElement(By.XPath("//span[contains(text(), 'Waiters')]/parent::div/parent::a"));
        protected IWebElement _administratorsButton => driver.FindElement(By.XPath("//span[contains(text(), 'Administrators')]/parent::div/parent::a"));

        public ManageRestaurantPageComponent ClickDetailsButton()
        {
            _detailsButton.Click();
            return this;
        }
        public ManageMenuesPageComponent ClickMenuesButton()
        {
            _menuesButton.Click();
            return new ManageMenuesPageComponent(driver);
        }
        public ManageWaitersPage ClickWaitersButton()
        {
            _waitersButton.Click();
            return new ManageWaitersPage(driver);
        }
        public ManageAdministratorPage ClickAdministratorsButton()
        {
            _administratorsButton.Click();
            return new ManageAdministratorPage(driver);
        }
    }



}

