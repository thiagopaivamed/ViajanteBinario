using System;
using System.Threading;
using ViajanteBinario.Implementacoes;
using ViajanteBinario.Interfaces;

namespace ViajanteBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Viajante Binário - Viaje o mundo";

            IServicoTwitter _servicoTwitter = new ServicoTwitter();

            while(true)
            {
                _servicoTwitter.EnviarTweet();
                Console.WriteLine("[Program - {0}] Função executada", DateTime.Now);
                Thread.Sleep(6000000);
            }
        }
    }
}
