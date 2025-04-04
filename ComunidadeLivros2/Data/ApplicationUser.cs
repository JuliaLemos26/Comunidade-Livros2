using ComunidadeLivros2.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace ComunidadeLivros2.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Livro>? LivrosFavoritos { get; set; }
    }

}
