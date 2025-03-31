using ComunidadeLivros2.Data.Models;

namespace ComunidadeLivros2.Services
{
    public interface IMidiaService
    {
        Task<IList<Midia>> GetAllMidia();
        Task<Midia?> GetMidiaById(Guid id);
        Task UpdateMidia(Midia midia);
        Task AddMidia(Midia newMidia);
        Task DeleteMidia(Midia midia);
    }
}
