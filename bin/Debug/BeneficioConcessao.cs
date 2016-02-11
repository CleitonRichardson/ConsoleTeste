using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace ConsoleTeste
{
    [TestFixture]
    public class BeneficioConcessao
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(System.IO.Path.Combine(Environment.CurrentDirectory, "ChromeDriver"));
            baseURL = "http://vegeta.vitalbusiness.com.br/WebAppTeste/Login/Index/?id=/WebAppTeste";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheBeneficioConcessaoTest()
        {
            //CODIGO COPIADO DA CLASSE LoginValido
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("usuario")).Clear();
            driver.FindElement(By.Name("usuario")).SendKeys("cleiton");
            driver.FindElement(By.Name("senha")).Clear();
            driver.FindElement(By.Name("senha")).SendKeys("123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            //depende do browser estar maximizado, para que a expressão "bem vindo" seja exibida e assim possa ser capturada            
            var value = driver.FindElement(By.Id("user-info")).Text;
            var contains = value.ToLower().IndexOf("cleiton") != -1;
            Assert.IsTrue(contains);

            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Beneficio/RealizacaoConcessao");
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("canvas-for-livicon-6")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("CodigoDoProcesso")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("CodigoDoProcesso")).SendKeys("123456789");
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("dp1455208152249")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.LinkText("1")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("dp1455208152250")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.LinkText("2")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Name("Numero")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Name("Numero")).SendKeys("987654321");
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("dp1455208152251")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.LinkText("3")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("incluirAnexo")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("inputUploadDeArquivos")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("inputUploadDeArquivos")).SendKeys("C:\\Users\\Charles\\Desktop\\COF.txt");
            Thread.Sleep(2000);            
            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("btn-registrar_concessao")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();
            Thread.Sleep(2000);            
            Assert.AreEqual("Concessão registrada com sucesso!", driver.FindElement(By.CssSelector("ul.item-list > li")).Text);
            Thread.Sleep(2000);            
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
