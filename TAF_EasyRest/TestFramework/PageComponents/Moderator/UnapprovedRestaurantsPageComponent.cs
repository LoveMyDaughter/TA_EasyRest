namespace TestFramework.PageComponents.Moderator
{
    public class UnapprovedRestaurantsPageComponent
    {
        private IWebDriver driver { get; }

        public UnapprovedRestaurantsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> _restaurantsGrid => driver.FindElements(By.XPath("//div[contains(@class, 'Grid-item')]"));

        public int RestaurantsCount()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => _restaurantsGrid.Count > 0);
            return _restaurantsGrid.Count();
        }

        public UnapprovedRestaurantsPageComponent ClickApproveButton()
        {
            var firstRestaurantFromGrid = _restaurantsGrid.ElementAt(0);
            var approveButton = firstRestaurantFromGrid.FindElement(By.XPath(".//span[text() = 'Approve']/parent::button"));
            approveButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.StalenessOf(approveButton));
            return new UnapprovedRestaurantsPageComponent(driver);
        }
    }
}
