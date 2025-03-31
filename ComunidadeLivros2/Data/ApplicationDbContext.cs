using ComunidadeLivros2.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Livro> Livros => Set<Livro>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Autor> Autores => Set<Autor>();
        public DbSet<Midia> Midias => Set<Midia>();
    }
}
