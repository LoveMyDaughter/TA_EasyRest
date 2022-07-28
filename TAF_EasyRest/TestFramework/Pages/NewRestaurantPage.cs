﻿using TestFramework.PageComponents.NavigationMenuComponents;
using TestFramework.PageComponents;

namespace TestFramework.Pages 
{
    public class NewRestaurantPage : BasePage
    {
        public NavigationMenuPageComponent NavigationMenu { get;}

        public NewRestaurantPage(IWebDriver driver) : base(driver)
        {
            NavigationMenu = new NavigationMenuPageComponent(driver);
        }

        private IWebElement _AddButton => driver.FindElement(By.XPath("//button[@title='Add restaurant']"));
        
        public NewRestaurantPageComponet ClickAddButton()
        {
            _AddButton.Click();
            return new NewRestaurantPageComponet(driver);
        }
    }
}