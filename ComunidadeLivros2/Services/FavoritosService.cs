using ComunidadeLivros2.Data;
using ComunidadeLivros2.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace ComunidadeLivros2.Services
{
    public class FavoritosService : IFavoritosService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILivroService _livroService;

        public FavoritosService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILivroService livroService)
        {
            _context = context;
            _userManager = userManager;
            _livroService = livroService;
        }

        public async Task<IList<Livro>?> GetAllFavoritos(ApplicationUser user)
        {
            await Task.Delay(5);

            return user?.LivrosFavoritos;
        }

        public async void AddFavorite(ApplicationUser user, Guid livroId)
        {
            var livro = await _livroService.GetLivroById(livroId);

            if (livro != null)
            {
                livro.UsuariosFavoritos.Add(user);
                _context.Update(livro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
