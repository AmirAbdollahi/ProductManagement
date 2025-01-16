using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product("Sample Product 1", new Domain.ValueObjects.Money(199.99m), Domain.Enums.ProductCategory.Electronics),
                new Product("Sample Product 2", new Domain.ValueObjects.Money(299.99m), Domain.Enums.ProductCategory.Clothing)
            );

            modelBuilder.Entity<Specification>().HasData(
                new Specification("Color", "Red"),
                new Specification("Size", "Medium")
            );
        }
    }

}
