namespace TestFramework.PageComponents.Owner
{
    public class ChangeItemComonMenuPageComponent
    {
        private IWebDriver driver;
        public ChangeItemComonMenuPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements
        private IWebElement _currentElement => driver.FindElement(By.XPath("(//tr[contains(@class,'MuiTableRow-root-209 MuiTableRow-hover-211 MenuTable-tableRow-178 MenuTable-tableRowHover-180')])[1]"));
        private IWebElement _nameField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[3]"));
        private IWebElement _descriptionField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[4]"));
        private IWebElement _ingredientsField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[5]"));
        private IWebElement _valueField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[6]"));
        private IWebElement _priceField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[7]"));
        private IWebElement _categoryField => _currentElement.FindElement(By.XPath("(//td[contains(@class, 'MuiTableCell-body')])[9]"));
        #endregion

        #region Methods
        public ChangeItemComonMenuPageComponent SetName(string keys)
        {
            _nameField.Click();
            _nameField.SendKeys(keys);
            return this;
        }

        public ChangeItemComonMenuPageComponent SetDescription(string keys)
        {
            _descriptionField.Click();
            _descriptionField.SendKeys(keys);
            return this;
        }

        public ChangeItemComonMenuPageComponent SetIngredients(string keys)
        {
            _ingredientsField.Click();
            _ingredientsField.SendKeys(keys);
            return this;
        }

        public ChangeItemComonMenuPageComponent SetValue(double keys)
        {
            _valueField.Click();
            _valueField.SendKeys(keys.ToString());
            return this;
        }

        public ChangeItemComonMenuPageComponent SetPrice(double keys)
        {
            _priceField.Click();
            _priceField.SendKeys(keys.ToString());
            return this;
        }

        public ChangeItemComonMenuPageComponent SetCategory(int index)
        {
            _categoryField.Click();
            var category = _categoryField.FindElement(By.XPath($"//option[@value='{index}']"));
            category.Click();
            return this;
        }
        #endregion
    }
}
