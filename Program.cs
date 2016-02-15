
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var TesteLoginInvalido = new LoginInvalido();
            var TesteLoginValido = new LoginValido();
            var TesteProspeccaoVenda = new ProspeccaoVenda();
            var TesteMotivoNaoInteresse = new MotivoNaoInteresse();
            var TesteAvaliacaoPrevia = new AvaliacaoPrevia();
            var TesteRegistroDocumentacao = new RegistroDocumentacao();
            var TesteConferenciaDocumentacao = new ConferenciaDocumentacao();
            var TesteBeneficioConcessao = new BeneficioConcessao();


            
            try

            {

                //TesteLoginInvalido.SetupTest();
                //TesteLoginInvalido.TheLoginInvalidoTest();

                //TesteLoginValido.SetupTest();
                //TesteLoginValido.TheLoginValidoTest();

                TesteProspeccaoVenda.SetupTest();
                TesteProspeccaoVenda.TheProspeccaoVendaTest();

                //TesteMotivoNaoInteresse.SetupTest();
                //TesteMotivoNaoInteresse.TheMotivoNaoInteresseTest();

                //TesteAvaliacaoPrevia.SetupTest();
                //TesteAvaliacaoPrevia.TheAvaliacaoPreviaTest();

                //TesteRegistroDocumentacao.SetupTest();
                //TesteRegistroDocumentacao.TheRegistroDocumentacaoTest();

                //TesteConferenciaDocumentacao.SetupTest();
                //TesteConferenciaDocumentacao.TheConferenciaDocumentacaoTest();

                //TesteBeneficioConcessao.SetupTest();
                //TesteBeneficioConcessao.TheBeneficioConcessaoTest();


                Console.WriteLine("Sucesso!");
                Thread.Sleep(3000);
                

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                //TesteLoginInvalido.TeardownTest();
                //TesteLoginValido.TeardownTest();
                TesteProspeccaoVenda.TeardownTest();
                //TesteMotivoNaoInteresse.TeardownTest();
                //TesteAvaliacaoPrevia.TeardownTest();
                //TesteRegistroDocumentacao.TeardownTest();
                //TesteConferenciaDocumentacao.TeardownTest();
                //TesteBeneficioConcessao.TeardownTest();

            }
        }
    }
}
