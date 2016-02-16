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



            #region LOGIN [CÓPIA DA CLASSE LoginValido]
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("usuario")).Clear();
            Thread.Sleep(500);
            driver.FindElement(By.Name("usuario")).SendKeys("cleiton");
            driver.FindElement(By.Name("senha")).Clear();
            Thread.Sleep(500);
            driver.FindElement(By.Name("senha")).SendKeys("123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            //depende do browser estar maximizado, para que a expressão "bem vindo" seja exibida e assim possa ser capturada            
            var value = driver.FindElement(By.Id("user-info")).Text;
            var contains = value.ToLower().IndexOf("cleiton") != -1;
            Assert.IsTrue(contains);
            #endregion


            ////TENTATIVA, AINDA FALHA, DE FAZER FUNCIONAR A CAPTURA, NA DA MODAL UPLOAD DE AQUIVOS DE ARQUIVOS, NA TELA EM REGISTRO DE DOCUMENTAÇÃO
            //driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Beneficio/SolicitacaoBeneficio");
            //Thread.Sleep(3000);
            //driver.FindElement(By.Id("canvas-for-livicon-6")).Click();
            //Thread.Sleep(6000);
            //driver.FindElement(By.XPath("//a[@onclick=\"exibirModal('4106849d-d303-4bd8-885f-52549dde805c');return true;\"]")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//input[@id='inputUploadDeArquivos']")).Clear();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//input[@id='inputUploadDeArquivos']")).SendKeys("C:\\Users\\Charles\\Desktop\\COF.txt");
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();


         
        }

            //#region SOLUÇÃO ENCONTRADA PELO FABIO PARA O FUNCIONAMENTO DO "AVANÇAR" E "RETORNAR" MÊS, NO ELEMENTO CALENDÁRIO
            //driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/Prospeccao");
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div[@id='tabela']/div/div[3]/div[2]/span/button")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//input[@id='Edit-DataProspeccao']")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']/div/a[2]")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']/div/a[2]")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']/div/a[2]")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//a[contains(text(),'2')]")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//textarea[@id='Edit-Observacoes']")).Clear();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//textarea[@id='Edit-Observacoes']")).SendKeys("porrraaaaaaaaa");
            //#endregion

            //            #region CREATE
//            //não consegui colocar a seleção dos submenus, já que estes não dependem de click, sendo assim só o último menu é registrado
//            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/Prospeccao");
//            Thread.Sleep(1000); //TEMPO DE ESPERA INSERIDO MANUALMENTE, SEM O QUAL O TESTE NÃO FUNCIONA                                    
//            //Assert: Captura a expressão que exibe o numero de registros (ex.: 1 a 10 de 12)
//            var numeroRegistros = (driver.FindElement(By.CssSelector("span.jtable-page-info")).Text);
//            driver.FindElement(By.CssSelector("button.jtable-toolbar-item-text")).Click();
//            Thread.Sleep(500); //TEMPO DE ESPERA INSERIDO MANUALMENTE, SEM O QUAL O TESTE NÃO FUNCIONA                                    
//            driver.FindElement(By.LinkText("17")).Click();            
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("Edit-Observacoes")).Clear();
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("Edit-Observacoes")).SendKeys("Teste de CREATE");
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-PropostaId"))).SelectByText("Pré Inscrito Pouprev 015");
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-MotivoNaoInteresseId"))).SelectByText("Sou muito jovem para fazer previdência");
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-CorretorId"))).SelectByText("Marcos Medeiros");
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("AddRecordDialogSaveButton")).Click();
//            Thread.Sleep(1000); //tempo necesário para que o novo registro seja salvo e exibido.
//            //Compara a expressão que exibe o numero de registros antes e após a realizaçao do teste; se a expressão for diferente (FALSE) é porque houve sucesso no teste
//            Assert.AreNotEqual((driver.FindElement(By.CssSelector("span.jtable-page-info")).Text), numeroRegistros);
//            Thread.Sleep(1000);
//            #endregion

//            #region UPDATE
//            // É necessário abrir novamente a página; do contrário dá erro; não sei o porquê; até descobrir isso perdi mais de uma hora. Código inserido manualmente
//            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/Prospeccao");
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("livicon-6")).Click();
//            Thread.Sleep(500);
//            driver.FindElement(By.LinkText("22")).Click();
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("Edit-Observacoes")).Clear();
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("Edit-Observacoes")).SendKeys("Teste de UPDATE");            
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-PropostaId"))).SelectByText("Pré Inscrito Pouprev 007");
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-MotivoNaoInteresseId"))).SelectByText("Minha religião não permite");
//            Thread.Sleep(500);
//            new SelectElement(driver.FindElement(By.Id("Edit-CorretorId"))).SelectByText("Corretora Seguros Vida");
//            Thread.Sleep(500);         
//            driver.FindElement(By.Id("EditDialogSaveButton")).Click();
//            Thread.Sleep(500);
//            Assert.AreEqual("Registro alterado com sucesso", driver.FindElement(By.CssSelector("div.gritter-without-image > p")).Text);
//            Thread.Sleep(3000);
//            #endregion 

//            #region DELETE
//            driver.FindElement(By.Id("livicon-7")).Click();
//            Thread.Sleep(500);
//            driver.FindElement(By.Id("DeleteDialogButton")).Click();
//            Thread.Sleep(3000);
//            Assert.AreEqual("Registro excluído com sucesso", driver.FindElement(By.CssSelector("div.gritter-without-image > p")).Text);
//            Thread.Sleep(6000);
//            #endregion
            
//            #region OUTROS COMANDOS (NAVEGAÇÃO ENTRE REGISTROS E PAGINAÇÃO)
//            driver.Navigate().GoToUrl("http://vegeta.vitalbusiness.com.br/WebAppTeste/Cadastro/Index/Prospeccao");
//            Thread.Sleep(3000);
//            driver.FindElement(By.CssSelector("span.jtable-page-number-next")).Click();
//            Thread.Sleep(3000);
//            driver.FindElement(By.CssSelector("span.jtable-page-number-next")).Click();
//            Thread.Sleep(3000);
//            driver.FindElement(By.CssSelector("span.jtable-page-number-last")).Click();
//            Thread.Sleep(3000);
//            driver.FindElement(By.CssSelector("span.jtable-page-number-first")).Click();
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("select"))).SelectByText("2");
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("select"))).SelectByText("4");
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("select"))).SelectByText("1");
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("span.jtable-page-size-change > select"))).SelectByText("25");
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("span.jtable-page-size-change > select"))).SelectByText("50");
//            Thread.Sleep(3000);
//            new SelectElement(driver.FindElement(By.CssSelector("span.jtable-page-size-change > select"))).SelectByText("10");
//            Thread.Sleep(3000);
//#endregion


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
