using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    internal class NavigationMenuPageComponent : BasePage
    {
        private IWebElement _EasyRestButton => driver.FindElement(By.XPath("//a[text()='Easy-rest']"));
        private IWebElement _HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement _RestaurantsList => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        private IWebElement _SignIn => driver.FindElement(By.XPath("//span[text()='Sign In']"));
        private IWebElement _SignUp => driver.FindElement(By.XPath("//span[text()='Sign Up']"));

        public NavigationMenuPageComponent(IWebDriver driver) : base(driver) { }

        public NavigationMenuPageComponent ClickEasyRestButton()
        {
            _EasyRestButton.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickHomeButton()
        {
            _HomeButton.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickRestaurantsListButton()
        {
            _RestaurantsList.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickSignInListButton()
        {
            _SignIn.Click();
            return this;
        }

        public NavigationMenuPageComponent ClickSignUpButton()
        {
            _SignUp.Click();
            return this;
        }


    }
}
