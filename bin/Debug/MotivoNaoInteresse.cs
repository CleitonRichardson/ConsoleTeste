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
    public class MotivoNaoInteresse
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
        public void TheMotivoNaoInteresseTest()
        {

            #region LOGIN [CÓPIA DA CLASSE LoginValido]
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
            #endregion

            #region CREATE
            //O Selenium não capturou a seleção dos SUBmenus; 
            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/MotivoNaoInteresse");            
            Thread.Sleep(3000); //TEMPO DE ESPERA INSERIDO MANUALMENTE, SEM O QUAL O TESTE NÃO FUNCIONA
            //Captura a expressão que exibe o numero de registros (ex.: 1 a 10 de 12)
            //var numeroRegistrosMotivoNaoInteresse = (driver.FindElement(By.CssSelector("span.jtable-page-info")).Text);    
            driver.FindElement(By.CssSelector("button.jtable-toolbar-item-text")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).SendKeys("Já tenho previdência");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("AddRecordDialogSaveButton")).Click();
            Assert.AreEqual("Já existe Motivo de não Interesse com esse nome.", driver.FindElement(By.CssSelector("div.formErrorContent")).Text);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).SendKeys("Já tenho previdência CREATE");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("AddRecordDialogSaveButton")).Click();
            //Compara a expressão que exibe o numero de registros antes e após a realizaçao do teste; se a expressão for diferente (FALSE) é porque houve sucesso no teste
            //Assert.AreNotEqual((driver.FindElement(By.CssSelector("span.jtable-page-info")).Text), numeroRegistrosMotivoNaoInteresse);
            Thread.Sleep(2000);
            Assert.AreEqual("Registro incluído com sucesso", driver.FindElement(By.CssSelector("div.gritter-without-image > p")).Text);
            #endregion

            #region UPDATE
            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/MotivoNaoInteresse");    
            //driver.FindElement(By.CssSelector("#mnMotivodeNãoInteresse > span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("livicon-4")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='Edit-Nome']")).SendKeys("Já tenho previdência UPDATE");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("EditDialogSaveButton")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Registro alterado com sucesso", driver.FindElement(By.CssSelector("div.gritter-without-image > p")).Text);
            Thread.Sleep(1000);
            #endregion

            #region DELETE
            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/MotivoNaoInteresse");    
            Thread.Sleep(1000);
            driver.FindElement(By.Id("livicon-5")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("DeleteDialogButton")).Click();
            Thread.Sleep(1000);            
            Assert.AreEqual("Registro excluído com sucesso", driver.FindElement(By.CssSelector("div.gritter-without-image > p")).Text);
            Thread.Sleep(1000);
            #endregion                   


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
