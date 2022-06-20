using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.Data.Users;
using NLog;


namespace TestFramework.Pages
{
    public enum LoginPageL10nFields
    {
        LOGIN_LABEL,
        PASSWORD_LABEL,
        SIGNIN_BUTTON
    }

    public class LoginPageL10nRepository
    {
        public static Dictionary<LoginPageL10nFields, Dictionary<ChangeLanguageFields, string>> LoginPageLanguages { get; private set; }

        static LoginPageL10nRepository()
        {
            LoginPageLanguages = new Dictionary<LoginPageL10nFields, Dictionary<ChangeLanguageFields, string>>();
            initLoginLabel();
            initPasswordLabel();
            initSigninButton();
        }

        private static void initLoginLabel()
        {
            LoginPageLanguages.Add(LoginPageL10nFields.LOGIN_LABEL,
                    new Dictionary<ChangeLanguageFields, string>()
                    {
                        { ChangeLanguageFields.UKRAINIAN, "Логін" },
                        { ChangeLanguageFields.RUSSIAN, "Логин" },
                        { ChangeLanguageFields.ENGLISH, "Login" }
                    }
                );
        }

        private static void initPasswordLabel()
        {
            LoginPageLanguages.Add(LoginPageL10nFields.PASSWORD_LABEL,
                    new Dictionary<ChangeLanguageFields, string>()
                    {
                        { ChangeLanguageFields.UKRAINIAN, "Пароль" },
                        { ChangeLanguageFields.RUSSIAN, "Пароль" },
                        { ChangeLanguageFields.ENGLISH, "Password" }
                    }
                );
        }

        private static void initSigninButton()
        {
            LoginPageLanguages.Add(LoginPageL10nFields.SIGNIN_BUTTON,
                    new Dictionary<ChangeLanguageFields, string>()
                    {
                        { ChangeLanguageFields.UKRAINIAN, "Увійти" },
                        { ChangeLanguageFields.RUSSIAN, "Войти" },
                        { ChangeLanguageFields.ENGLISH, "Sign in" }
                    }
                );
        }
    }

    public partial class LoginPage : ATopComponent
    {
        public Logger log = LogManager.GetCurrentClassLogger(); // for NLog


                //public LoginPage(IWebDriver driver) : base(driver)
        public LoginPage() : base()
        {
            // PageFactory
            //PageFactory.InitElements(driver, this);
            
            // Classic Page Object
            //InitWebElements();
            VerifyWebElements();
        }

        //private void InitWebElements()
        //{
        //    LoginLabel = driver.FindElement(By.XPath("//label[contains(@for,'inputEmail')]"));
        //    LoginInput = driver.FindElement(By.Id("login"));
        //    PasswordLabel = driver.FindElement(By.XPath("//label[contains(@for,'inputPassword')]"));
        //    PasswordInput = driver.FindElement(By.Id("password"));
        //    SigninButton = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
        //    LogoPicture = driver.FindElement(By.CssSelector("img.login_logo.col-md-8.col-xs-12"));
        //}

        private void VerifyWebElements()
        {
            IWebElement temp = LoginLabel;
            temp = LoginInput;
            temp = PasswordLabel;
            temp = PasswordInput;
            temp = SigninButton;
            temp = LogoPicture;
        }

        // PageObject Atomic

        // LoginLabel
        public string GetLoginLabelText()
        {
            return LoginLabel.Text.Trim();
        }

        public void ClickLoginLabel()
        {
            LoginLabel.Click();
        }

        // LoginInput
        public string GetLoginInputText()
        {
            return LoginInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void SetLoginInput(string text)
        {
            LoginInput.SendKeys(text);
        }

        public void ClearLoginInput()
        {
            LoginInput.Clear();
        }

        public void ClickLoginInput()
        {
            LoginInput.Click();
        }

        // Functional
        //public void SetLoginInputClear(string text)
        public LoginPage SetLoginInputClear(string text)
        {
            ClickLoginInput();
            ClearLoginInput();
            SetLoginInput(text);
            return this;
        }

        // PasswordLabel
        public string GetPasswordLabelText()
        {
            return PasswordLabel.Text.Trim();
        }

        public void ClickPasswordLabel()
        {
            PasswordLabel.Click();
        }

        // PasswordInput
        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void SetPasswordInput(string text)
        {
            PasswordInput.SendKeys(text);
        }

        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        public void ClickPasswordInput()
        {
            PasswordInput.Click();
        }

        // Functional
        public LoginPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        // SigninButton
        public string GetSigninButtonText()
        {
            return SigninButton.Text.Trim();
        }

        public void ClickSigninButton()
        {
            SigninButton.Click();
        }

        // LogoPicture
        public string GetLogoPictureSrcAttributeText()
        {
            return LogoPicture.GetAttribute(SRC_ATTRIBUTE);
        }

        public void ClickLogoPicture()
        {
            LogoPicture.Click();
        }

        // Business Logic
        //public LoginPage ChangeLanguage(string language) // Invalid Solution
        public new LoginPage ChangeLanguage(ChangeLanguageFields languageFields)
        {
            SetChangeLanguage(languageFields);
            //return new LoginPage(driver);
            return new LoginPage();
        }

        private void SetLoginData(IUser user)
        //private void SetLoginData(string login, string password)
        {
            log.Debug("SetLoginData() Start, user.Login= " + user.GetLogin());
            SetLoginInputClear(user.GetLogin());
            log.Trace("SetLoginData(), Point 1, user.Login= " + user.GetLogin());
            //SetLoginInputClear(login);
            SetPasswordInputClear(user.GetPassword());
            log.Trace("SetLoginData(), Point 2, user.Login= " + user.GetLogin());
            //SetPasswordInputClear(password);
            ClickSigninButton();
            log.Debug("SetLoginData() Done, user.Login= " + user.GetLogin());
        }

        public RepeatLoginPage unsuccessfulLogin(IUser invalidUser)
        //public RepeatLoginPage unsuccessfulLogin(string invalidLogin, string invalidPassword)
        {
            SetLoginData(invalidUser);
            //SetLoginData(invalidLogin, invalidPassword);
            //return new RepeatLoginPage(driver);
            return new RepeatLoginPage();
        }

        public RegistratorHomePage successRegistratorLogin(IUser registrator)
        //public RegistratorHomePage successRegistratorLogin(string registratorLogin, string registratorPassword)
        {
            SetLoginData(registrator);
            //SetLoginData(registratorLogin, registratorPassword);
            //return new RegistratorHomePage(driver);
            return new RegistratorHomePage();
        }

    }
}
