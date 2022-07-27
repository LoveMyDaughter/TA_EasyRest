﻿using TestFramework.PageComponents;
using TestFramework.PageComponents.NavigationMenuComponents;

namespace TestFramework.Pages
{
    public class OwnerPanelRestaurantsPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenuPageComponent { get; }
        public PersonalInfoPageComponent PersonalInfoPageComponent { get; }

        public OwnerPanelRestaurantsPage(IWebDriver driver) : base(driver)
        {
            PersonalInfoPageComponent = new PersonalInfoPageComponent(driver);
            NavigationMenuPageComponent = new NavigationMenuPageComponent(driver);
        }


        #region Elements

        // This button is bind to not archived restaurants. Otherwise we can't archive the restaurant
        private IWebElement _threeDotButton => driver.FindElement(By.XPath("//span[text() != 'ARCHIVED']/ancestor::div/button"));
        private IWebElement _addRestaurantButton => driver.FindElement(By.XPath("//button[@title = 'Add restaurant']"));

        // For this buttons: use wait until threeDotButton expands
        private IWebElement _manageButton => driver.FindElement(By.XPath("//span[text() = 'Manage']/ancestor::a"));
        private IWebElement _archiveButton => driver.FindElement(By.XPath("//span[text() = 'Archive']/ancestor::li"));

        #endregion


        #region Methods

        public OwnerPanelRestaurantsPage ClickThreeDotButton()
        {
            _threeDotButton.Click();
            return this;
        }

        public OwnerPanelRestaurantsPage ClickArchiveButton()
        {
            _threeDotButton.Click();
            _archiveButton.Click();
            return this;
        }

        public OwnerPanelRestaurantsPage ClickManageButton()
        {
            _threeDotButton.Click();
            _manageButton.Click();
            return this;
        }
        public OwnerPanelRestaurantsPage ClickAddRestaurantButton()
        {
            _addRestaurantButton.Click();
            return this;
        }


        #endregion

    }
}