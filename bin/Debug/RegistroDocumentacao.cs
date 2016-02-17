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
    public class RegistroDocumentacao
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
        public void TheRegistroDocumentacaoTest()
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


            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Beneficio/SolicitacaoBeneficio");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("canvas-for-livicon-6")).Click();  //esse tive que pegar na mão... indo lá, vendo o código HTML e digitando aqui
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.CssSelector("select"))).SelectByText("Sim");
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='exibicaoDeMensagem']/div[9]/div[2]/div/form/div/div/div/table[2]/tbody/tr[2]/td[5]/select"))).SelectByText("Sim");
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='exibicaoDeMensagem']/div[9]/div[2]/div/form/div/div/div/table[2]/tbody/tr[3]/td[5]/select"))).SelectByText("Sim");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("a.ico-anexo")).Click();
            Thread.Sleep(3000);

            //O Selenium não pega a funcionalidade de Upload; o código abaixo, que faz o upload funcionar, foi obtido na Internet após MUUUUUITA pesquisa; 
            //http://sqa.stackexchange.com/questions/15103/testing-the-downloading-uploading-of-files-with-selenium-ide-webdriver-other
            IWebElement element = driver.FindElement(By.Name("inputUploadDeArquivos"));
            element.SendKeys(@"C:\\Users\\Charles\\Desktop\\COF.txt");

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn-disp_solic_para_conf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Solicitação transferida para conferência de documentos", driver.FindElement(By.CssSelector("ul.item-list > li")).Text);
            Thread.Sleep(2000);
            //Até aqui o teste é baseado no funcionamento padrão, onde é necessário anexar de forma obrigatória apenas UM documento.
            //O problema é que algumas vezes é necessário anexar mais de um documento (Quando na Avaliação Prévia é selecionado "Pensão Por Morte", por exemplo).
            //
            //localizei um defeito: Se clico no ícone para anexar um arquivo, mas em, seguida fecho a modal sem selecionar arquivo algum, quando clico novamente
            //no ícone novamente para anexar um arquivo, a tela fica cinza e não é possível mais usar o sistema... sendo necessário realizar um REFRESh para que volte ao normal.
            //
            //Ao tentar "Diponibilizar uma proposta" sem anexar documento que seja de anexação obrigatória, é aberta uma caixa de diálogo para que seja digitada uma justificativa.



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
