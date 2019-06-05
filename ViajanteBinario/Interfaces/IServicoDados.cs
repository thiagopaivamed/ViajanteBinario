using System;
using System.Collections.Generic;
using System.Text;

namespace ViajanteBinario.Interfaces
{
    public interface IServicoDados
    {
        string PegarUrlImagem();
        string PegarMensagem();
        int GerarIndice(int numeroMaximo);
    }
}
