using System;
using System.Collections.Generic;
using System.Text;
using TweetSharp;

namespace ViajanteBinario.Interfaces
{
    public interface IServicoTwitter
    {
        TwitterService ConfigurarUsuarioTwitter();
        void EnviarTweet();
    }
}
