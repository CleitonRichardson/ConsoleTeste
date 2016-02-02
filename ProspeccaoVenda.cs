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
    public class ProspeccaoVenda
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
        public void TheProspeccaoVendaTest()
        {

            //Códico COPIADO da classe LoginValido            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("usuario")).Clear();
            driver.FindElement(By.Name("usuario")).SendKeys("cleiton");
            driver.FindElement(By.Name("senha")).Clear();
            driver.FindElement(By.Name("senha")).SendKeys("123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                                                
            // depende do browser estar maximizado, para que a expressão "bem vindo" seja exibida e assim possa ser capturada            
            var value = driver.FindElement(By.Id("user-info")).Text;
            var contains = value.ToLower().IndexOf("cleiton") != -1;
            Assert.IsTrue(contains);

            //não consegui colocar a seleção dos submenus, já que estes não dependem de click, sendo assim só o último menu é registrado
            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/Prospeccao");                     
            //driver.FindElement(By.CssSelector("#mnProspecçãoeVenda > span")).Click();
                        
            
            Thread.Sleep(5000); //TEMPO DE ESPERA INSERIDO MANUALMENTE, SEM O QUAL O TESTE NÃO FUNCIONA
            driver.FindElement(By.CssSelector("button.jtable-toolbar-item-text")).Click();
            Thread.Sleep(4000); //TEMPO DE ESPERA INSERIDO MANUALMENTE, SEM O QUAL O TESTE NÃO FUNCIONA
            //driver.FindElement(By.LinkText("Prev")).Click(); //DURANTE O PREENCHIMENTO DO CAMPO DATA, NO CALENDÁRIO, NÃO ACEITA VOLTAR OU AVANÇAR O MÊS
            driver.FindElement(By.LinkText("17")).Click(); 
            driver.FindElement(By.Id("Edit-Observacoes")).Clear();
            driver.FindElement(By.Id("Edit-Observacoes")).SendKeys("Testedo08:01");
            new SelectElement(driver.FindElement(By.Id("Edit-PropostaId"))).SelectByText("Pré Inscrito Pouprev 015");            
            new SelectElement(driver.FindElement(By.Id("Edit-MotivoNaoInteresseId"))).SelectByText("Sou muito jovem para fazer previdência");
            new SelectElement(driver.FindElement(By.Id("Edit-CorretorId"))).SelectByText("Marcos Medeiros");
            driver.FindElement(By.Id("AddRecordDialogSaveButton")).Click();
            

            
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