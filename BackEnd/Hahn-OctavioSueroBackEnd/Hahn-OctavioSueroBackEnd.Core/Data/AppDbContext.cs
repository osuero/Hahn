using Hahn_OctavioSueroBackEnd.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_OctavioSueroBackEnd.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1200.99m, Stock = 15 },
                new Product { Id = 2, Name = "Mouse", Price = 25.50m, Stock = 100 },
                new Product { Id = 3, Name = "Keyboard", Price = 45.99m, Stock = 50 }
            );
        }
    }
}
