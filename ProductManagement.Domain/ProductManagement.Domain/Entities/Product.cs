using ProductManagement.Domain.Enums;
using ProductManagement.Domain.ValueObjects;
using System.Xml.Linq;

namespace ProductManagement.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<Specification> Specifications { get; private set; }

        public Product(string name, decimal price, ProductCategory category)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name), message: "Product name cannot be empty");
            var thePrice = price <= 0 ? throw new ArgumentNullException(nameof(price), message: "Price must be greater than zero") : price;
            Price = new Money(thePrice);
            Category = category;
            Specifications = new List<Specification>();
        }
        
        public Product(string name, Money price, ProductCategory category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), message: "Product name cannot be empty");

            Id = Guid.NewGuid();
            Name = name;
            Price = price ?? throw new ArgumentNullException(nameof(price), message: "Price must be greater than zero");
            Category = category;
            Specifications = new List<Specification>();
        }

        public void AddSpecification(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Specification key cannot be null or empty.", nameof(key));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Specification value cannot be null or empty.", nameof(value));

            Specifications.Add(new Specification(key, value));
        }

        public void UpdatePrice(Money newPrice)
        {
            Price = newPrice ?? throw new ArgumentNullException(nameof(newPrice));
        }

        public void ChangeCategory(ProductCategory newCategory)
        {
            Category = newCategory;
        }

        public void Update(string name, Money price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price ?? throw new ArgumentNullException(nameof(price));
        }

        public void ClearSpecifications()
        {
            Specifications.Clear();
        }
    }
}
