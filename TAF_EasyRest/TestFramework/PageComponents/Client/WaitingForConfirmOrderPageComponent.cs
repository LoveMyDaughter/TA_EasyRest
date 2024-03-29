﻿namespace TestFramework.PageComponents
{
    public class WaitingForConfirmOrderPageComponent
    {
        private IWebDriver driver;
        private int index;
        public string number => _orderField.FindElement(By.XPath($"//div[@class='MuiGrid-item-120 MuiGrid-grid-xs-1-148'][1]")).Text;

        public WaitingForConfirmOrderPageComponent(IWebDriver driver, int index)
        {
            this.driver = driver;
            this.index = index;
        }

        private IWebElement _orderField => driver.FindElement(By.XPath($"//div[contains(@class,'MuiExpansionPanel-rounded')][{index}]"));

        public WaitingForConfirmOrderDetailsPageComponent ExpandOrderField()
        {
            _orderField.Click();
            return new WaitingForConfirmOrderDetailsPageComponent(driver, index, number);
        }
    }
}
