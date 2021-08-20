using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace googleTestSearch
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://google.com";
            Thread.Sleep(2000);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}