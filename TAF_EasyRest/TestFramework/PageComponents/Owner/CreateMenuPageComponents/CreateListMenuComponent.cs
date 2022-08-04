using TestFramework.Pages.Owner;

namespace TestFramework.PageComponents.Owner.CreateMenuPageComponents
{
    public class CreateListMenuComponent 
    {
        IWebDriver driver { get; }

        public CreateListMenuComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
  
        private IWebElement _threeDotsButton => driver.FindElement(By.XPath(".//button[@aria-label='Action']"));
        private IWebElement _nextButton => driver.FindElement(By.XPath(".//button[@aria-label='Action']/parent::div/parent::div/parent::div/parent::div/following-sibling::div[2]"));
        private IWebElement _backButton => driver.FindElement(By.XPath(".//button[@aria-label='Action']/parent::div/parent::div/parent::div/parent::div/following-sibling::div[1]"));

        public CreateListMenuComponent ClickThreeDotsButton()
        {
            _threeDotsButton.Click();
            return this;
        }
        public CreateListMenuComponent ClickNextButton()
        {
            _nextButton.Click();
            return this;
        }

        public CreateMenuPage ClickBackButton(
            )
        {
            _backButton.Click();
            return new CreateMenuPage(driver);
        }
    }

}
