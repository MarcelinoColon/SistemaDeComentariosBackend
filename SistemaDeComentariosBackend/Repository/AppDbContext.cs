using Microsoft.EntityFrameworkCore;
using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
