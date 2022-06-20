using System;
using System.Windows;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Windows.Forms;
using System.Threading;
using NUnit.Allure.Core;

namespace TestFramework
{
    //[TestClass]
    [AllureNUnit]
    [TestFixture]
  // [Parallelizable(ParallelScope.All)]
    public class UnitTest1
    {
        //[TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("start");
            //int i = 0;
            double i = 0;
            Console.WriteLine("(i+1)/i= " + (i + 1) / i);
            Console.WriteLine("done");
            //throw new Exception("ha-ha-ha");
        }

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()",
            //    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()",
            //    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        //[TestMethod]
        [Test]
        public void TestMethod1(
            [Values("Hello", "World")]
            string s,
            [Random(1,10,5)]
            int x)
        {
            Console.WriteLine("Ok, s=" + s + " x=" + x);
        }

        //[TestCase(5, ExpectedResult = true)]
        //[TestCase(-15, ExpectedResult = false)]
        public bool TestMethod2(int x)
        {
            return x > 0;
        }

        // DataProvider
        private static readonly object[] ConverterData =
        {
            new object[] { 65, 'A' },
            new object[] { 97, 'a' },
            new object[] { 98, 'b' }
        };

        //[TestCase(65, 'A')]
        //[TestCase(97, 'a')]
        //[Test, TestCaseSource(nameof(ConverterData))]
        public void TestMethod3(int x, char c)
        {
            Console.WriteLine("ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("x=" + x + " c=" + c);
            char expexted = c;
            char actual = (char)x;
            Assert.AreEqual(expexted, actual);
        }

    }
}
