using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public interface ILivroService
    {
        Task<IList<Livro>> GetAllLivro();
        Task<Livro?> GetLivroById(Guid id);
        Task UpdateLivro(Livro livro);
        Task AddLivro(Livro newLivro);
        Task DeleteLivro(Livro livro);
        Task<IList<Livro>> GetLivrosByAutorId(Guid autorId);
        Task<IList<Livro>> GetLivrosByGeneroId(Guid generoId);
        Task<IList<Livro>> GetLivrosFiltered(string searchText);
        Task<(IList<Livro>, int)> GetLivrosFilteredPaged(string searchText, int pageNumber, int pageSize);
    }
}
