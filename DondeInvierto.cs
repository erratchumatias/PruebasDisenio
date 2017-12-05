using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace PruebasDondeInvierto
{
    [TestClass]
    public class DondeInvierto
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        [TestMethod]
        public void PruebaLoginOKEY()
        {
            
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            Assert.IsTrue(Regex.IsMatch(driver.Title, "Inicio - ¿Dónde invierto?"));
            driver.Quit();
        }

        [TestMethod]
        public void PruebaLoginERROR()
        {

            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            Assert.IsTrue(Regex.IsMatch(driver.Title, "Ingresar - ¿Dónde invierto?"));
            driver.Quit();
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

    }
}