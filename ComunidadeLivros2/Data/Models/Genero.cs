using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivros2.Data.Models
{
    public class Genero
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Nome { get; set; } = null; 

        public List<Livro> Livros { get; set; } = new();

        public List<Autor> Autores { get; set; } = new();
    }
}
