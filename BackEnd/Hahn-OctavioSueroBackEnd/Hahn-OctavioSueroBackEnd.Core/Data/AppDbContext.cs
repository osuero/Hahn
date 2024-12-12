using Hahn_OctavioSueroBackEnd.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_OctavioSueroBackEnd.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
