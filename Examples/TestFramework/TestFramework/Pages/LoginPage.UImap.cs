using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;


namespace TestFramework.Pages
{

    public partial class LoginPage : ATopComponent
    {
        public const string IMAGE_NAME = "ukraine_logo2.gif";

        public IWebElement LoginLabel => Search.XPath("//label[contains(@for,'inputEmail')]");
        public IWebElement SomeElement(string value) => Search.XPath($"//label[contains(@for,'{value}')]");     
        public IWebElement PasswordLabel => Search.XPath("//label[contains(@for,'inputPassword')]");
        public IWebElement PasswordInput => Search.Id("password");
        public IWebElement SigninButton => Search.CssSelector("button.btn.btn-primary");
        public IWebElement LogoPicture => Search.CssSelector("img.login_logo.col-md-8.col-xs-12");
        public IWebElement LoginInput => Search.Id("login");


        //Приклад ініціалізації елементів через PageFactory
        [CacheLookup] //використовуючи атрибут [CacheLookup]  ми при потребі можемо кешувати елементи,
                      //тобто не шукати їх щоразу, тест працюватиме швидше, але при рефреші
                      //сторінки ми стикатимемось з втратою посилання змінної на об'єкти сторінки
        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginInput_PageFactoryExample { get; private set; }

    }
}
