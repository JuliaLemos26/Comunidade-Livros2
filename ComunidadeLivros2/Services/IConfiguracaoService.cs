using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public interface IConfiguracaoService
    {
        string TemaAtual { get; }
        void AlterarTema(string novoTema);
        void RegistrarCallback(Action<string> callback);
        void RemoverCallback(Action<string> callback);

    }
}
