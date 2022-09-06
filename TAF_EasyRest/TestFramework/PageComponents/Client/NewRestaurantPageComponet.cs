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
        private By _nameField => By.XPath("//input[@name='name']");
        private By _adressField => By.XPath("//input[@name='address']");
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

        public NewRestaurantPageComponet ClickNameField(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_nameField, timeToWait)
                .Click();
            return this;
        }
        public NewRestaurantPageComponet ClickAdressField(int timeToWait)
        {
            driver.WaitUntilElementIsVisible(_adressField, timeToWait)
                .Click();
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

        public NewRestaurantPage ClickCancelButton()
        {
            _cancelButton.Click();
            return new NewRestaurantPage(driver);
        }

        //List of restaurants are needed
        public OwnerPanelRestaurantsPage ClickAddButton(int timeToWait)
        {
            _addButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'RestaurantListItem-card')]")));
            return new OwnerPanelRestaurantsPage(driver);
        }

        #endregion


        #region SendKeys Methods

        public NewRestaurantPageComponet SendKeysNameField(string name)
        {
            driver.FindElement(_nameField).SendKeys(name);
            return this;
        }

        public NewRestaurantPageComponet SendKeysAdressField(string adress)
        {
            driver.FindElement(_adressField).SendKeys(adress);
            return this;
        }

        public NewRestaurantPageComponet SendKeysPhoneField(string phone)
        {
            _phoneField.SendKeys(phone);
            return this;
        }

        public NewRestaurantPageComponet SendKeysTextField(string text)
        {
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