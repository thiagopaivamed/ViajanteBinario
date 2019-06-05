using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ViajanteBinario.Interfaces;

namespace ViajanteBinario.Implementacoes
{
    public class ServicoDados : IServicoDados
    {
        private IServicoBancoDados _servicoBancoDados = new ServicoBancoDados();

        public int GerarIndice(int numeroMaximo)
        {
            try
            {
                return new Random().Next(0, numeroMaximo);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ServicoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public string PegarMensagem()
        {
            try
            {
                string mensagem = String.Empty;

               if(_servicoBancoDados.VerificarBancoDadosMensagensExiste())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[ServicoDados - {0}] Pegando mensagem\n", DateTime.Now);
                    Console.ResetColor();
                    string[] listaMensagens = File.ReadAllLines(_servicoBancoDados.PegarDiretorioMesangensArquivo());
                    int indice = GerarIndice(listaMensagens.Length - 1);
                    mensagem = listaMensagens[indice];
                    return mensagem;
                }

                return mensagem;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ServicoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public string PegarUrlImagem()
        {
            try
            {
                string urlFoto = String.Empty;

                if (_servicoBancoDados.VerificarBancoDadosImagensExiste())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[ServicoDados - {0}] Pegando mensagem\n", DateTime.Now);
                    Console.ResetColor();
                    string diretorioImagem = _servicoBancoDados.PegarDiretorioImagens();
                    string[] listaImagens = File.ReadAllLines(_servicoBancoDados.PegarDiretorioImagensArquivo());
                    int indice = GerarIndice(listaImagens.Length - 1);
                    urlFoto = listaImagens[indice];
                    return diretorioImagem + urlFoto;
                }

                return urlFoto;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ServicoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }
    }
}
