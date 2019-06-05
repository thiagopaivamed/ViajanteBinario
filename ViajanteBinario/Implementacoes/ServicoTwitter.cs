using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TweetSharp;
using ViajanteBinario.Interfaces;

namespace ViajanteBinario.Implementacoes
{
    public class ServicoTwitter : IServicoTwitter
    {

        private const string apiKey = "JKCQxETtpfc0YNDwrEE83QWzQ";
        private const string apiSecretKey = "h7YagrykLnRoqKOWFfxUo8tOgbMKMr7x9Q3tN8oUsF0P7ajYBL";
        private const string accessToken = "1116847969985335301-zFBuuA1qSHdk0k2hwk95qXL2CB82wc";
        private const string accessTokenSecret = "WVLn9FCryizk0HMAQNCLCQ3SBFJQsD7UmXg9iktVinMHS";
        private const string hashTags = "#viaje #viagens #paraiso #mundo";
        private IServicoDados _servicoDados = new ServicoDados();

        public TwitterService ConfigurarUsuarioTwitter()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[ServicoTwitter - {0}] Autenticando usuário\n", DateTime.Now);
                TwitterService usuario = new TwitterService(apiKey, apiSecretKey, accessToken, accessTokenSecret);
                Console.WriteLine("[ServicoTwitter - {0}] Usuário autenticado\n", DateTime.Now);
                Console.ResetColor();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoTwitter - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                Console.ResetColor();
                throw ex;
            }
        }

        public void EnviarTweet()
        {
            try
            {
                string urlImagem = _servicoDados.PegarUrlImagem();
                string mensagem = _servicoDados.PegarMensagem();
                string tweet = MontarTweet(mensagem, hashTags);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[ServicoTwitter - {0}] Preparando envio do tweet\n", DateTime.Now);

                using (FileStream fileStream = new FileStream(urlImagem, FileMode.Open))
                {
                    TwitterService twitterService = ConfigurarUsuarioTwitter();

                    Console.WriteLine("[ServicoTwitter - {0}] Enviando tweet\n", DateTime.Now);

                    twitterService.SendTweetWithMedia(new SendTweetWithMediaOptions
                    {
                        Status = tweet,
                        Images = new Dictionary<string, Stream> { { urlImagem, fileStream } }

                    });

                    Console.WriteLine("[ServicoTwitter - {0}] Tweet enviado\n", DateTime.Now);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoTwitter - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                Console.ResetColor();
                throw ex;
            }
        }

        public string MontarTweet(string mensagem, string hashTags)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[ServicoTwitter - {0}] Montando tweet\n", DateTime.Now);
                return mensagem + "\n" + hashTags;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ServicoTwitter - {0}] Erro -> {1}", DateTime.Now, ex.Message);
                Console.ResetColor();
                throw ex;
            }
        }
    }
}
