using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public interface IGeneroService
    {
        Task<IList<Genero>> GetAllGeneros();
        Task<Genero?> GetGeneroById(Guid id);
        Task UpdateGenero(Genero genero);
        Task AddGenero(Genero newGenero);
        Task DeleteGenero(Genero genero);
    }
}
