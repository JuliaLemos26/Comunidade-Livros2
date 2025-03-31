using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly ApplicationDbContext _context;

        public GeneroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Genero>> GetAllGeneros()
        {
            return await _context.Generos.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Genero?> GetGeneroById(Guid id)
        {
            return await _context.Generos.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task UpdateGenero(Genero genero)
        {
            _context.Update(genero);
            await _context.SaveChangesAsync();
        }

        public async Task AddGenero(Genero genero)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenero(Genero genero)
        {
            _context.Remove(genero);
            await _context.SaveChangesAsync();
        }
    }
}
