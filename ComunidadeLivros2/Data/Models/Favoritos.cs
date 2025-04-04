using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Data.Models
{
    public class Favorito
    {
        public Guid Id { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Livro? Livro { get; set; }

        [ForeignKey("Usuario")]
        public required string UsuarioId { get; set; }

        //public required IdentityUser Usuario { get; set; }
    }
}
