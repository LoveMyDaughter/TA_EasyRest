using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.PageComponents.NavigationMenuComponents
{
    public class UserMenuHeaderButton
    {
        IWebDriver driver { get; set; }

        protected static TimeSpan timeout = TimeSpan.FromSeconds(3);

        public UserMenuHeaderButton(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement _UserMenu => driver.FindElement(By.XPath("//button/span[@class='MuiIconButton-label-2477']/div"));

        public UserMenuDropDownListPageComponent ClickOnUserMenuButton()
        {
            _UserMenu.Click();
            return new UserMenuDropDownListPageComponent(driver);
        }
    }
}
