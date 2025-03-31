using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Services
{
    public class MidiaService : IMidiaService
    {
        private readonly ApplicationDbContext _context;
        public MidiaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Midia>> GetAllMidia()
        {
            return await _context.Midias.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Midia?> GetMidiaById(Guid id)
        {
            return await _context.Midias.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task UpdateMidia (Midia midia)
        {
            _context.Update(midia);
            await _context.SaveChangesAsync();
        }

        public async Task AddMidia(Midia midia)
        {
            _context.Add(midia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMidia(Midia midia)
        {
            _context.Remove(midia);
            await _context.SaveChangesAsync();
        }
    }
}
