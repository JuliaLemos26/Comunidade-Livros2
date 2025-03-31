using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Autor>> GetAllAutor()
        {
            return await _context.Autores
                .Include(x => x.Genero)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<Autor?> GetAutorById(Guid id)
        {
            return await _context.Autores
                                 .Include(x => x.Midia)
                                 .Include(x => x.Genero)
                                 .Include(x => x.Livros)
                                 .FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task UpdateAutor(Autor autor)
        {
            _context.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task AddAutor(Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutor(Autor autor)
        {
            _context.Remove(autor);
            await _context.SaveChangesAsync();
        }

        public async Task AddAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);  
            await _context.SaveChangesAsync();  
        }

        public async Task<IList<Autor>> GetAutoresByGeneroId(Guid generoId)
        {
            return await _context.Autores.Where(x => x.Genero != null && x.Genero.Id == generoId).ToListAsync();
        }

    }
}
