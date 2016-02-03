
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                                    
            
            try
            {

                //TesteLoginInvalido.SetupTest();
                //TesteLoginInvalido.TheLoginInvalidoTest();

                //TesteLoginValido.SetupTest();
                //TesteLoginValido.TheLoginValidoTest();

                //TesteProspeccaoVenda.SetupTest();
                //TesteProspeccaoVenda.TheProspeccaoVendaTest();

                //TesteMotivoNaoInteresse.SetupTest();
                //TesteMotivoNaoInteresse.TheMotivoNaoInteresseTest();

                TesteAvaliacaoPrevia.SetupTest();
                TesteAvaliacaoPrevia.TheAvaliacaoPreviaTest();

                Console.WriteLine("Sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                //TesteLoginInvalido.TeardownTest();
                //TesteLoginValido.TeardownTest();
                //TesteProspeccaoVenda.TeardownTest();
                //TesteMotivoNaoInteresse.TeardownTest();
                TesteAvaliacaoPrevia.TeardownTest();

            }
        }
    }
}
