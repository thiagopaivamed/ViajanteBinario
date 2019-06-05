using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ViajanteBinario.Interfaces;

namespace ViajanteBinario.Implementacoes
{
    public class ServicoBancoDados : IServicoBancoDados
    {
        private const string arquivoImagensNome = "ImagensBancoDados.txt";
        private const string arquivoMensagensNome = "MensagensBancoDados.txt";

        public void CriarBancoDadosMensagens()
        {
            try
            {
                if(! VerificarBancoDadosMensagensExiste())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[ServicoBancoDados - {0}] Criando banco de mensagens\n", DateTime.Now);
                    File.Create(PegarDiretorioMesangensArquivo()).Close();
                    Console.WriteLine("[ServicoBancoDados - {0}] Banco de mensagens criado\n", DateTime.Now);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public void CriarBancoDandosImagens()
        {
            try
            {
                if (!VerificarBancoDadosMensagensExiste())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[ServicoBancoDados - {0}] Criando banco de imagens\n", DateTime.Now);
                    File.Create(PegarDiretorioImagensArquivo()).Close();
                    Console.WriteLine("[ServicoBancoDados - {0}] Banco de imagens criado\n", DateTime.Now);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public string PegarDiretorioBancoDados()
        {
            try
            {
                string diretorioProjeto = AppDomain.CurrentDomain.BaseDirectory;
                StringBuilder stringBuilder = new StringBuilder(diretorioProjeto);
                int indice = diretorioProjeto.LastIndexOf(@"bin");

                while(indice < diretorioProjeto.Length)
                {
                    stringBuilder[indice] = ' ';
                    indice = indice + 1;
                }

                string caminhoProjeto = new StringBuilder(stringBuilder.ToString().Trim()).Append(@"BancoDados\").ToString();

                return caminhoProjeto;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public string PegarDiretorioImagens()
        {
            try
            {
                string diretorioProjeto = AppDomain.CurrentDomain.BaseDirectory;
                StringBuilder stringBuilder = new StringBuilder(diretorioProjeto);
                int indice = diretorioProjeto.LastIndexOf(@"bin");

                while (indice < diretorioProjeto.Length)
                {
                    stringBuilder[indice] = ' ';
                    indice = indice + 1;
                }

                string caminhoProjeto = new StringBuilder(stringBuilder.ToString().Trim()).Append(@"Imagens\").ToString();

                return caminhoProjeto;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public string PegarDiretorioImagensArquivo()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ServicoBancoDados - {0}] Pegando o diretório de imagens\n", DateTime.Now);
                Console.ResetColor();
                return PegarDiretorioBancoDados() + arquivoImagensNome;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
          
        }

        public string PegarDiretorioMesangensArquivo()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ServicoBancoDados - {0}] Pegando o diretório de mensagens\n", DateTime.Now);
                Console.ResetColor();
                return PegarDiretorioBancoDados() + arquivoMensagensNome;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public bool VerificarBancoDadosImagensExiste()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Verificando se banco de imagens existe\n");
                Console.ResetColor();
                return File.Exists(PegarDiretorioImagensArquivo());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        public bool VerificarBancoDadosMensagensExiste()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Verificando se banco de mensagens existe\n");
                Console.ResetColor();
                return File.Exists(PegarDiretorioMesangensArquivo());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoBancoDados - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                throw ex;
            }
        }
    }
}
