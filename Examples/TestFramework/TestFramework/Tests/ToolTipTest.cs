using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestFramework
{
    [TestFixture]
    public class ToolTipTest
    {
        [Test]
        public void ExpectedConditions1()
        {
            IWebDriver driver = new ChromeDriver();
            //
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            //IWebElement searchElement = wait.Until<IWebElement>(ExpectedConditions.InvisibilityOfElementLocated(By.Name("q")));
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void ToolTipTestSkype()
        {

            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.skype.com/en/");
            //
            IWebElement blogsElement = driver.FindElement(By.PartialLinkText("Blogs"));
            string blogsText = blogsElement.Text;
            Console.WriteLine("blogsText=" + blogsText + "=end");
            Thread.Sleep(2000);
            //
            Actions action = new Actions(driver);
            action.ClickAndHold().MoveToElement(blogsElement).Build().Perform();

            Thread.Sleep(3000);
            //
            string toolTipText = driver.FindElement(By.CssSelector("a[href='https://skype.com/en/blogs']")).Text;
            Console.WriteLine("blogsElement=" + toolTipText + "=end");
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void CheckToolTip()
        {

            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("file:///C:/tooltip.html");
            //
            IWebElement element = driver.FindElement(By.XPath("//*[@id='gbwa']/div/a"));
            //
            Actions action = new Actions(driver);
            action.ClickAndHold().MoveToElement(element).Build().Perform();

            Thread.Sleep(2000);
            //
            Console.WriteLine("Text= " + element.Text + " =end");
            Console.WriteLine("ToolTip= " + element.GetAttribute("aria-label") + " =end");
            //
            Assert.AreEqual("Додатки Google", element.GetAttribute("aria-label"));
            //
            driver.Quit();
        }

    }
}
