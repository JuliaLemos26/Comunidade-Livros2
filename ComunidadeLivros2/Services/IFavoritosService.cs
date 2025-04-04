using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public interface IFavoritosService
    {
        public Task<IList<Livro>?> GetAllFavoritos(ApplicationUser user);
        void AddFavorite(ApplicationUser user, Guid livroId);
    }
}
