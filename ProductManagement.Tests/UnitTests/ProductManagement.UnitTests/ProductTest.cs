using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enums;
using ProductManagement.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace ProductManagement.UnitTests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsEmpty()
        {
            // Arrange
            string name = "";
            decimal price = 100m;
            var money = new Money(price);
            var category = ProductCategory.Furniture;

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => new Product(name, money, category));
            exception.Message.ShouldContain("Product name cannot be empty");
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenPriceIsZeroOrNegative()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 0m;
            var money = new Money(price);
            var category = ProductCategory.Furniture;

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => new Product(name, money, category));
            exception.Message.ShouldContain("Price must be greater than zero");

            // Test with negative price
            price = -5m;
            exception = Should.Throw<ArgumentException>(() => new Product(name, money, category));
            exception.Message.ShouldContain("Price must be greater than zero");
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenDescriptionIsEmpty()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 100m;
            var money = new Money(price);
            var category = ProductCategory.Furniture;

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => new Product(name, money, category));
            exception.Message.ShouldContain("Description cannot be empty");
        }

        [Fact]
        public void Constructor_ShouldCreateProduct_WhenValidData()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 100m;
            var money = new Money(price);
            var category = ProductCategory.Furniture;

            // Act
            var product = new Product(name, money, category);

            // Assert
            product.Name.ShouldBe(name);
            product.Price.Value.ShouldBe(price);
            product.Category.ShouldBe(category);
        }

        [Fact]
        public void UpdatePrice_ShouldThrowArgumentException_WhenNewPriceIsZeroOrNegative()
        {
            // Arrange
            decimal price = 100m;
            var money = new Money(price);
            var category = ProductCategory.Furniture;
            var product = new Product("Test Product", money, category);

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => product.UpdatePrice(new Money(0)));
            exception.Message.ShouldContain("Price must be greater than zero");

            // Test with negative price
            exception = Should.Throw<ArgumentException>(() => product.UpdatePrice(new Money(-5)));
            exception.Message.ShouldContain("Price must be greater than zero");
        }

        [Fact]
        public void UpdatePrice_ShouldUpdatePrice_WhenValidNewPrice()
        {
            // Arrange
            var product = new Product("Test Product", new Money(100m), ProductCategory.Food);

            // Act
            product.UpdatePrice(new Money(150m));

            // Assert
            product.Price.Value.ShouldBe(150m);
        } 
    }
}
