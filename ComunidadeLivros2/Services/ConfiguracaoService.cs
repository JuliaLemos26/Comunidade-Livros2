using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Services
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private string _temaAtual = "Light";
        private readonly List<Action<string>> _callbacks = new();

        public string TemaAtual => _temaAtual;

        public void AlterarTema(string novoTema)
        {
            if (_temaAtual != novoTema)
            {
                _temaAtual = novoTema;

                // Notificar todos os callbacks registrados
                foreach (var callback in _callbacks)
                {
                    callback(novoTema);
                }
            }
        }

        public void RegistrarCallback(Action<string> callback)
        {
            if (!_callbacks.Contains(callback))
            {
                _callbacks.Add(callback);
            }
        }

        public void RemoverCallback(Action<string> callback)
        {
            if (_callbacks.Contains(callback))
            {
                _callbacks.Remove(callback);
            }
        }
    }
}
