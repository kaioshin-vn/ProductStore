using Microsoft.EntityFrameworkCore;
using ProductStore.Model.Table;

namespace ProductStore.Model
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Catetory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.;Database=ProductDb;Trusted_Connection=True; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
