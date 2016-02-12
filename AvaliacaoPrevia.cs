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
    public class AvaliacaoPrevia
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
        public void TheAvaliacaoPreviaTest()
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
                       


            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Beneficio/AvaliacaoPrevia"); //Link direto inserido manualmente em razão de ainda nao conseguir fazer pelo Menu
            Thread.Sleep(5000);

            //Captura a expressão que exibe o numero de registros (ex.: 1 a 10 de 12)
            var numeroRegistrosAvaliacaoPrevia = (driver.FindElement(By.CssSelector("span.jtable-page-info")).Text);           
            
            driver.FindElement(By.Id("canvas-for-livicon-4")).Click();  //esse tive que pegar na mão... indo lá, vendo o código HTML e digitando aqui
            Thread.Sleep(3000);
            driver.FindElement(By.Id("percentualMaximoDeSaque")).Clear(); //esse tive que pegar na mão... indo lá, vendo o código HTML e digitando aqui
            Thread.Sleep(2000);
            driver.FindElement(By.Id("percentualMaximoDeSaque")).SendKeys("2500"); // o valor máximo é de 30%. FAZER UMA ROTINA QUE VERIFICA ESSE VALOR MÁXIMO
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn-continuar")).Click();
            Thread.Sleep(15000);   
            driver.FindElement(By.XPath("//div[@id='accordion']/div[2]/div/h4/a/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.Id("Opcoes"))).SelectByText("Renda Vitalícia com Cotas Decrescentes");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("Opcao01")).Click();
            Thread.Sleep(2000);                
            driver.FindElement(By.XPath("(//button[@type='button'])[23]")).Click();
            Thread.Sleep(5000);

            //Compara a expressão que exibe o numero de registros antes e após a realizaçao do teste; se a expressão for diferente (FALSE) é porque houve sucesso no teste
            Assert.AreNotEqual((driver.FindElement(By.CssSelector("span.jtable-page-info")).Text), numeroRegistrosAvaliacaoPrevia);
            Thread.Sleep(6000);

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
