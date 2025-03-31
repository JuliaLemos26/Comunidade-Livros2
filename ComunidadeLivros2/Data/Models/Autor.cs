using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Data.Models
{
    public class Autor
    {
        public Guid Id { get; set; }

        public required string Nome { get; set; }

        public required string Sobre { get; set; }

        public List<Livro>? Livros { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Genero? Genero { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Midia? Midia { get; set; }
    }
}
