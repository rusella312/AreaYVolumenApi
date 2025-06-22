using Microsoft.EntityFrameworkCore;
using AreaYVolumenApi.Models;

namespace AreaYVolumenApi.Data
{
    public class MangaDbContext : DbContext
    {
        public MangaDbContext(DbContextOptions<MangaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cilindro> Cilindros { get; set; }
        public DbSet<Cubo> Cubos { get; set; }
    }
}