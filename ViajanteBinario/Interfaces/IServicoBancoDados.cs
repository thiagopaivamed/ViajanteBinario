using System;
using System.Collections.Generic;
using System.Text;

namespace ViajanteBinario.Interfaces
{
    public interface IServicoBancoDados
    {
        string PegarDiretorioBancoDados();
        string PegarDiretorioImagens();
        string PegarDiretorioMesangensArquivo();
        string PegarDiretorioImagensArquivo();
        void CriarBancoDadosMensagens();
        void CriarBancoDandosImagens();
        bool VerificarBancoDadosMensagensExiste();
        bool VerificarBancoDadosImagensExiste();
    }
}
