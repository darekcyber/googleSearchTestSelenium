using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace googleTestSearch
{
    [TestFixture]
    public class Tests
    {
        static string url = "https://google.com";
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [TestCase("banan")]
        [TestCase("pomarancza")]
        public void TestWitchDifferentWords(String searchText)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            try
            {
                driver.FindElement(By.Id("L2AGLb")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Terms of use not found");
            }

            driver.FindElement(By.Name("q")).SendKeys(searchText);

            Thread.Sleep(1000);

            WebDriverWait searchButton= new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            searchButton.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("btnK"))).Click();

            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}