using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivros2.Data.Models
{
    public class Midia
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Nome { get; set; } = null;

        public required string MidiaLink { get; set; }

        public List<Livro> Livros { get; set; } = new();

        public List<Autor> Autores { get; set; } = new();
    }
}
