namespace TestFramework.PageComponents
{
    public class NewRestaurantPageComponet
    {
        private IWebDriver driver;
        public NewRestaurantPageComponet(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements
        private IWebElement _nameField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement _adressField => driver.FindElement(By.XPath("//input[@name='address']"));
        private IWebElement _phoneField => driver.FindElement(By.XPath("//input[@name='phone']"));
        private IWebElement _textField => driver.FindElement(By.XPath("//textarea"));
        private IWebElement _tagsSelector => driver.FindElement(By.XPath("//div[@id='select-tags']"));
        
        private IWebElement _headingButton => driver.FindElement(By.XPath("//button[@title='Heading']"));
        private IWebElement _blockquoteButton => driver.FindElement(By.XPath("//button[@title='Blockquote']"));
        private IWebElement _ulButton => driver.FindElement(By.XPath("//button[@title='UL']"));
        private IWebElement _olButton => driver.FindElement(By.XPath("//button[@title='OL']"));
        private IWebElement _boldButton => driver.FindElement(By.XPath("//button[@title='Bold']"));
        private IWebElement _italicButton => driver.FindElement(By.XPath("//button[@title='Italic']"));
        private IWebElement _underlineButton => driver.FindElement(By.XPath("//button[@title='Underline']"));

        private IWebElement _cancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']/parent::button"));
        private IWebElement _addButton => driver.FindElement(By.XPath("//span[text()='Add']/parent::button"));

        #endregion


        #region Click Methods

        public NewRestaurantPageComponet ClickNameField()
        {
            _nameField.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickAdressField()
        {
            _adressField.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickPhoneField()
        {
            _phoneField.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickTextField()
        {
            _textField.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickTagsField()
        {
            _tagsSelector.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickHeadingButton()
        {
            _headingButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickBlockquoteButton()
        {
            _blockquoteButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickULButton()
        {
            _ulButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickOLButton()
        {
            _olButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickBoldButton()
        {
            _boldButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickItalicButton()
        {
            _italicButton.Click();
            return this;
        }
        public NewRestaurantPageComponet ClickUnderlineButton()
        {
            _underlineButton.Click();
            return this;
        }

        public NewRestaurantPageObject ClickCancelButton()
        {
            _cancelButton.Click();
            return new NewRestaurantPageObject(driver);
        }

        //List of restaurants are needed
        public NewRestaurantPageComponet ClickAddButton()
        {
            _addButton.Click();
            return new NewRestaurantPageComponet(driver);
        }

        #endregion



        #region SendKeys Methods

        public NewRestaurantPageComponet SendKeysNameField(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
            return this;
        }

        public NewRestaurantPageComponet SendKeysAdressField(string adress)
        {
            _adressField.Clear();
            _adressField.SendKeys(adress);
            return this;
        }

        public NewRestaurantPageComponet SendKeysPhoneField(string phone)
        {
            _phoneField.Clear();
            _phoneField.SendKeys(phone);
            return this;
        }

        public NewRestaurantPageComponet SendKeysTextField(string text)
        {
            _textField.Clear();
            _textField.SendKeys(text);
            return this;
        }

        public NewRestaurantPageComponet SendKeysTagsSelector(string tag)
        {
            driver.FindElement(By.XPath($"//li[@data-value='{tag}']")).Click();
            return this;
        }

        #endregion

    }
}