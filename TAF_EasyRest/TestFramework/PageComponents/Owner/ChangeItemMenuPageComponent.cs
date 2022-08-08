namespace TestFramework.PageComponents.Owner
{
    public class ChangeItemMenuPageComponent
    {
        private IWebDriver driver;
        public ChangeItemMenuPageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements
        private IWebElement _currentElement => driver.FindElement(By.XPath("//tr[contains(@class,'MenuTable-tableRowHover-')][1]"));
        private IWebElement _nameField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[3]"));
        private IWebElement _descriptionField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[4]"));
        private IWebElement _ingredientsField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[5]"));
        private IWebElement _valueField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[6]"));
        private IWebElement _priceField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[7]"));
        private IWebElement _categoryField => _currentElement.FindElement(By.XPath("(.//td[contains(@class, 'MuiTableCell-body')])[9]"));
        private IWebElement _saveButton => _currentElement.FindElement(By.XPath(".//button"));
        #endregion

        #region Methods
        public ChangeItemMenuPageComponent SetName(string keys)
        {
            _nameField.Click();
            _nameField.Clear();
            _nameField.SendKeys(keys);
            return this;
        }

        public ChangeItemMenuPageComponent SetDescription(string keys)
        {
            _descriptionField.Click();
            _descriptionField.Clear();
            _descriptionField.SendKeys(keys);
            return this;
        }

        public ChangeItemMenuPageComponent SetIngredients(string keys)
        {
            _ingredientsField.Click();
            _ingredientsField.Clear();
            _ingredientsField.SendKeys(keys);
            return this;
        }

        public ChangeItemMenuPageComponent SetValue(double keys)
        {
            _valueField.Click();
            _valueField.Clear();
            _valueField.SendKeys(keys.ToString());
            return this;
        }

        public ChangeItemMenuPageComponent SetPrice(double keys)
        {
            _priceField.Click();
            _priceField.Clear();
            _priceField.SendKeys(keys.ToString());
            return this;
        }

        public MenuItemsPage ClickSaveButton()
        {
            _saveButton.Click();
            return new MenuItemsPage(driver);
        }

        public ChangeItemMenuPageComponent SetCategory(int index)
        {
            _categoryField.Click();
            var category = _categoryField.FindElement(By.XPath($"//option[@value='{index}']"));
            category.Click();
            return this;
        }
        #endregion
    }
}
