using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Data.Models
{
    public class Livro
    {
        internal Guid AutorId;

        public required Guid Id { get; set; }
        public required string Name { get; set; }

        public required string Sinopse { get; set; }

        public string? Sobre { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Genero? Genero { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Autor? Autor { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Midia? Midia { get; set; }

    }
}
