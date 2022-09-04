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

        public int RestaurantsCount()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => _restaurantsGrid.Count > 0);
            return _restaurantsGrid.Count();
        }

        public ArchivedRestaurantsPageComponent FindAndClickRestoreButton()
        {
            var firstRestaurantFromGrid = _restaurantsGrid.ElementAt(0);
            var restoreButton = firstRestaurantFromGrid.FindElement(By.XPath(".//span[text() = 'Restore']/parent::button"));
            restoreButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.StalenessOf(restoreButton));
            return new ArchivedRestaurantsPageComponent(driver);
        }
    }
}
