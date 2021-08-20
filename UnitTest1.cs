using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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

            driver.FindElement(By.Name("q")).SendKeys("baNaN");

            Thread.Sleep(1000);

            WebDriverWait searchButton= new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            searchButton.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("btnK"))).Click();

            //driver.FindElement(By.Name("btnK")).Click();

            Thread.Sleep(2000);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}