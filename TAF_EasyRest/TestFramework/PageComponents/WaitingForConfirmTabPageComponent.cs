using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.PageComponents
{
    public class WaitingForConfirmTabPageComponent
    {
        IWebDriver driver;
        private IWebElement _ordersContainer => driver.FindElement(By.XPath("//body/div/main/div/div/div/div"));
        private IReadOnlyCollection<IWebElement> _orders => _ordersContainer.FindElements(By.XPath("/div"));

        public WaitingForConfirmTabPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WaitingForConfirmOrderCardPageComponent ExpandAnyOrder()
        {
            var card = _orders.ElementAt(0);

            var expandButton = card.FindElement(By.XPath("//button"));
            expandButton.Click();

            return new WaitingForConfirmOrderCardPageComponent(driver);
        }
    }
}
