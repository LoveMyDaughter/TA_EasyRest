namespace TestFramework.PageComponents.Moderator
{
    public class ArchivedRestaurantsPageComponent
    {
        private IWebDriver driver { get; }

        public ArchivedRestaurantsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> _restaurantsGrid => driver.FindElements(By.XPath("//div[contains(@class, 'Grid-item')]"));



        public ArchivedRestaurantsPageComponent FindAndClickRestoreButton()
        {
            var firstRestaurantFromGrid = _restaurantsGrid.ElementAt(0);
            var restoreButton = firstRestaurantFromGrid.FindElement(By.XPath(".//span[text() = 'Restore']/parent::button"));

            restoreButton.Click();

            return new ArchivedRestaurantsPageComponent(driver);
        }
    }
}
