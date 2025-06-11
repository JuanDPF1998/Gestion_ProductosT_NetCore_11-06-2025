using Gestion_ProductosT.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_ProductosT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductosModel> productos { get; set; }
    }
}
