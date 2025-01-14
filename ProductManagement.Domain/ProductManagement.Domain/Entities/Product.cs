using ProductManagement.Domain.Enums;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<Specification> Specifications { get; private set; }

        public Product(string name, Money price, ProductCategory category)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price ?? throw new ArgumentNullException(nameof(price));
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
    }
}
