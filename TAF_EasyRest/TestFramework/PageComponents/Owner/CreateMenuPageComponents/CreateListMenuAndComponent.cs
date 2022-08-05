
namespace TestFramework.PageComponents.Owner.CreateMenuPageComponents
{
    public class CreateListMenuAndComponent
    {
            IWebDriver driver { get; }

            public CreateListMenuAndComponent(IWebDriver driver)
            {
                this.driver = driver;
            }

            private IWebElement _finishButton => driver.FindElement(By.XPath("//p[contains(text(), 'Try out')]/parent::div/following-sibling::div[2]"));
            private IWebElement _backButton => driver.FindElement(By.XPath("//p[contains(text(), 'Try out')]/parent::div/following-sibling::div[1]"));

            public CreateListMenuAndComponent ClickFinishButton()
            {
                _finishButton.Click();
                return this;
            }
            public CreateListMenuComponent ClickBackButton()
            {
                _backButton.Click();
                return new CreateListMenuComponent(driver);
            }

         
        
    }
}
