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

        [TestMethod]
        public void PruebaValorEnCuenta()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Cuentas")).Click();
            new SelectElement(driver.FindElement(By.Id("EmpresaSeleccionada"))).SelectByText("Erratchu");
            driver.FindElement(By.XPath("//input[@value='Seleccionar']")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Detalles')])[10]")).Click();
            Assert.AreEqual("400000.00", driver.FindElement(By.XPath("//div[8]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void PorracinValuadoEnRoi()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Indicadores")).Click();
            new SelectElement(driver.FindElement(By.Id("EmpresaSeleccionada"))).SelectByText("Porracin");
            new SelectElement(driver.FindElement(By.Id("IndicadorSeleccionado"))).SelectByText("ROI");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("0.30", driver.FindElement(By.XPath("//td[6]")).Text);
            Assert.AreEqual("0.36", driver.FindElement(By.XPath("//tr[3]/td[6]")).Text);
            Assert.AreEqual("0.33", driver.FindElement(By.XPath("//tr[4]/td[6]")).Text);
            Assert.AreEqual("0.04", driver.FindElement(By.XPath("//tr[5]/td[6]")).Text);
            Assert.AreEqual("0.39", driver.FindElement(By.XPath("//tr[6]/td[6]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void FeiguinValuadoEnRoe()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Indicadores")).Click();
            new SelectElement(driver.FindElement(By.Id("EmpresaSeleccionada"))).SelectByText("Feiguin");
            new SelectElement(driver.FindElement(By.Id("IndicadorSeleccionado"))).SelectByText("ROE");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("0.00", driver.FindElement(By.XPath("//td[6]")).Text);
            Assert.AreEqual("0.01", driver.FindElement(By.XPath("//tr[3]/td[6]")).Text);
            Assert.AreEqual("0.19", driver.FindElement(By.XPath("//tr[4]/td[6]")).Text);
            Assert.AreEqual("0.17", driver.FindElement(By.XPath("//tr[5]/td[6]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void MetodologiaLongevidad()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Metodologías")).Click();
            new SelectElement(driver.FindElement(By.Id("MetodologiaSeleccionada"))).SelectByText("Longevidad");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("Rochlin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[2]/td")).Text);
            Assert.AreEqual("Goldfarb", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[3]/td")).Text);
            Assert.AreEqual("Feiguin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[4]/td")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void MetodologiaEvaluacionROE()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Metodologías")).Click();
            new SelectElement(driver.FindElement(By.Id("MetodologiaSeleccionada"))).SelectByText("Maximizar ROE");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("Porracin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[2]/td")).Text);
            Assert.AreEqual("0.23", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[2]/td[3]")).Text);
            Assert.AreEqual("Goldfarb", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[3]/td")).Text);
            Assert.AreEqual("0.22", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[3]/td[3]")).Text);
            Assert.AreEqual("Feiguin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[4]/td")).Text);
            Assert.AreEqual("0.22", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[4]/td[3]")).Text);
            Assert.AreEqual("Rochlin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[5]/td")).Text);
            Assert.AreEqual("0.19", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[5]/td[3]")).Text);
            Assert.AreEqual("Erratchu", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[6]/td")).Text);
            Assert.AreEqual("0.18", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[6]/td[3]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void MetodologiaMinimizarNivelDeDeuda()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Metodologías")).Click();
            new SelectElement(driver.FindElement(By.Id("MetodologiaSeleccionada"))).SelectByText("Minimizar nivel de Deuda");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Assert.AreEqual("Feiguin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[2]/td")).Text);
            Assert.AreEqual("Rochlin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[3]/td")).Text);
            Assert.AreEqual("Goldfarb", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[4]/td")).Text);
            Assert.AreEqual("Erratchu", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[5]/td")).Text);
            Assert.AreEqual("Porracin", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[6]/td")).Text);
            Assert.AreEqual("0.06", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[2]/td[3]")).Text);
            Assert.AreEqual("0.06", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[3]/td[3]")).Text);
            Assert.AreEqual("0.07", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[4]/td[3]")).Text);
            Assert.AreEqual("0.10", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[5]/td[3]")).Text);
            Assert.AreEqual("0.12", driver.FindElement(By.XPath("//form[@id='form']/table/tbody/tr[6]/td[3]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Quit();
        }

        [TestMethod]
        public void CrearMetodologia()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dondeinviertodds.azurewebsites.net/";
            verificationErrors = new StringBuilder();

            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.LinkText("Metodologías")).Click();
            driver.FindElement(By.LinkText("Crear nueva metodologia")).Click();
            driver.FindElement(By.Name("Nombre")).Clear();
            driver.FindElement(By.Name("Nombre")).SendKeys("MetodologiaPruebaTest");
            new SelectElement(driver.FindElement(By.Id("indicador"))).SelectByText("IngresoNeto");
            new SelectElement(driver.FindElement(By.Id("operacion"))).SelectByText("Maximo");
            driver.FindElement(By.Name("Descripcion")).Clear();
            driver.FindElement(By.Name("Descripcion")).SendKeys("Maximo Ingreso Neto");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.AreEqual("MetodologiaPruebaTest", driver.FindElement(By.XPath("//tr[7]/td")).Text);
            Assert.AreEqual("Maximo Ingreso Neto", driver.FindElement(By.XPath("//tr[7]/td[2]")).Text);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
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