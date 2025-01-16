using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;


namespace ProductManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Specifications)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price.Value)
                .HasPrecision(18, 2);

            SeedData.Seed(modelBuilder);
        }
    }
}
