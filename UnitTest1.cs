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

        public bool isAlertPresent(){
        try{
            driver.SwitchTo().Alert();
            return true;
        }
        catch(Exception e){
            return false;
        }
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

            driver.FindElement(By.XPath("//*[@name='q']")).SendKeys(searchText);
            //driver.FindElement(By.Name("q")).SendKeys(searchText);

            WebDriverWait searchButton= new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            searchButton.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("btnK"))).Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string tekst = "alert('" + "Selenium szuka slowo " +searchText + "')";
  
            js.ExecuteScript(tekst);
  
            Thread.Sleep(2000);

            if(isAlertPresent()){
            driver.SwitchTo().Alert();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().DefaultContent();
        }
        }

        [OneTimeTearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}