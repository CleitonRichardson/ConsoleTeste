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
    public class ConferenciaDocumentacao
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
        public void TheConferenciaDocumentacaoTest()
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

            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Beneficio/ConferenciaDeDocumento");
            Thread.Sleep(2000);            
            driver.FindElement(By.CssSelector("section.principal")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("canvas-for-livicon-6")).Click();
            Thread.Sleep(2000);            
            new SelectElement(driver.FindElement(By.CssSelector("td.docAnaliseConferencia > select"))).SelectByText("Sim");
            Thread.Sleep(2000);            
            driver.FindElement(By.CssSelector("#canvas-for-livicon-2 > path")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).SendKeys("Observação um");
            Thread.Sleep(2000);            
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            Thread.Sleep(2000);            
            new SelectElement(driver.FindElement(By.XPath("//div[@id='exibicaoDeMensagem']/div[8]/div[2]/div/form/div/div/div/table[2]/tbody/tr[2]/td[6]/select"))).SelectByText("Sim");
            Thread.Sleep(2000);                  
            driver.FindElement(By.CssSelector("#canvas-for-livicon-3 > path")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).SendKeys("Observação dois");
            Thread.Sleep(2000);            
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            Thread.Sleep(2000);            
            new SelectElement(driver.FindElement(By.XPath("//div[@id='exibicaoDeMensagem']/div[8]/div[2]/div/form/div/div/div/table[2]/tbody/tr[3]/td[6]/select"))).SelectByText("Sim");
            Thread.Sleep(2000);            
            driver.FindElement(By.CssSelector("#canvas-for-livicon-4 > path")).Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).Clear();
            Thread.Sleep(2000);            
            driver.FindElement(By.Id("descricaoAnalise")).SendKeys("Observação  três");
            
            //DESSE PONTO EM DIANTE OCORRE UM ERRO (A tela fica cinza como se estivesse desabilitada para edição, e não volta até que faça um reload da mesma).
            //FOI MOSTRADO AO LEO E O MESMO VERIFICOU QUE SERIA UM ERRO DO PRÓPRIO SISTEMA, RAZÃO PELA QUAL SUSPENDO AQUI A AUTOMATIZAÇÃO DESTE TESTE, ATÉ QUE A CORREÇÃO SEJA REALZIADA

            //driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            //driver.FindElement(By.Id("btn-efetuar-solicitacao")).Click();
            //driver.FindElement(By.XPath("(//button[@type='button'])[7]")).Click();                        
            //Thread.Sleep(2000);            
            //driver.FindElement(By.CssSelector("path")).Click();
            //Thread.Sleep(2000);            
            //driver.FindElement(By.CssSelector("path")).Click();
            //Thread.Sleep(2000);            
            //driver.FindElement(By.Id("btn-efetuar-solicitacao")).Click();
            //Thread.Sleep(2000);            
            //driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            //Thread.Sleep(2000);            
            //Assert.AreEqual("Solicitação de benefício Nº 5403 encaminhada para concessão", driver.FindElement(By.CssSelector("ul.item-list > li")).Text);
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
