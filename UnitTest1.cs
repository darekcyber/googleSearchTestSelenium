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

            try
            {
                driver.FindElement(By.Id("L2AGLb")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Terms of use not found");
            }
            Thread.Sleep(2000);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}