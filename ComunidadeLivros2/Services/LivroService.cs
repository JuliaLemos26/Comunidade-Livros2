using Microsoft.EntityFrameworkCore;
using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public class LivroService : ILivroService
    {
        private readonly ApplicationDbContext _context;

        public LivroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Livro>> GetAllLivro()
        {
            return await _context.Livros
                .Include(x => x.Autor)
                .Include(x => x.Genero)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IList<Livro>> GetLivrosByAutorId(Guid autorId)
        {
            return await _context.Livros
                .Where(l => l.Autor != null && l.Autor.Id == autorId)
                .ToListAsync();
        }

        public async Task<Livro?> GetLivroById(Guid id)
        {
            return await _context.Livros
                                 .Include(x => x.Midia)
                                 .Include(x => x.Autor)
                                 .Include(x => x.Genero)
                                 .FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task UpdateLivro(Livro livro)
        {
            _context.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AddLivro(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivro(Livro livro)
        {
            _context.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AddLivroAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Livro>> GetLivrosByGeneroId(Guid generoId)
        {
            return await _context.Livros.Where(x => x.Genero != null && x.Genero.Id == generoId).ToListAsync();
        }

        public async Task<IList<Livro>> GetLivrosFiltered(string searchText)
        {
            return await _context.Livros
                .Where(x => x.Name.Contains(searchText) || (x.Autor != null && x.Autor.Nome.Contains(searchText)))
                .Include(x => x.Autor)
                .Include(x => x.Genero)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<(IList<Livro>, int)> GetLivrosFilteredPaged(string searchText, int pageNumber, int pageSize)
        {
            var query = _context.Livros
                .Where(x => x.Name.Contains(searchText) || (x.Autor != null && x.Autor.Nome.Contains(searchText)))
                .OrderBy(x => x.Name);

            int totalLivros = await query.CountAsync(); 
            var livros = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (livros, totalLivros);
        }
    }
}
