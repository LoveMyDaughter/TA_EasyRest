﻿namespace TestFramework.PageComponents.Moderator
{
    public class UnapprovedRestaurantsPageComponent
    {
        private IWebDriver driver;

        public UnapprovedRestaurantsPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> _restaurantsGrid => driver.FindElements(By.XPath("//div[contains(@class, 'Grid-item')]"));



        private IWebElement _approveButton => driver.FindElement(By.XPath("//span[text() = 'Approve']/parent::button"));

        public UnapprovedRestaurantsPageComponent ClickApproveButton()
        {
            var firstRestaurantFromGrid = _restaurantsGrid.ElementAt(0);
            var approveButton = firstRestaurantFromGrid.FindElement(By.XPath(".//span[text() = 'Approve']/parent::button"));

            approveButton.Click();

            return new UnapprovedRestaurantsPageComponent(driver);
        }




        public ArchivedRestaurantsPageComponent FindAndClickRestoreButton()
        {

        }

    }
}