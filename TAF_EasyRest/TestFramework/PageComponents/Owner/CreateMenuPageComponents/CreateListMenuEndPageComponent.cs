
namespace TestFramework.PageComponents.Owner.CreateMenuPageComponents
{
    public class CreateListMenuEndPageComponent
    {
            private IWebDriver driver { get; }
            public CreateListMenuEndPageComponent(IWebDriver driver)
            {
                this.driver = driver;
            }

            private IWebElement _finishButton => driver.FindElement(By.XPath("//p[contains(text(), 'Try out')]/parent::div/following-sibling::div[2]"));
            private IWebElement _backButton => driver.FindElement(By.XPath("//p[contains(text(), 'Try out')]/parent::div/following-sibling::div[1]"));
            public CreateListMenuEndPageComponent ClickFinishButton()
            {
                _finishButton.Click();
                return this;
            }
            public CreateListMenuPageComponent ClickBackButton()
            {
                _backButton.Click();
                return new CreateListMenuPageComponent(driver);
            }

         
        
    }
}
