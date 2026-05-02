using Microsoft.EntityFrameworkCore;
namespace demandas_sociais.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Demandas> Demandas { get; set; }

        public DbSet<Recursos> Recursos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }

}
