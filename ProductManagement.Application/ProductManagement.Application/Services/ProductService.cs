using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> CreateProductAsync(CreateProductDto productDto)
        {
            var price = new Money(productDto.Price);
            var product = new Product(productDto.Name, price, productDto.ProductCategory);

            foreach (var spec in productDto.Specifications)
            {
                product.AddSpecification(spec.Key, spec.Value);
            }

            await _productRepository.AddAsync(product);
            return product.Id;
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var price = new Money(productDto.Price);
            product.Update(productDto.Name, price);

            product.ClearSpecifications();
            foreach (var spec in productDto.Specifications)
            {
                product.AddSpecification(spec.Key, spec.Value);
            }

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Value,

                Specifications = product.Specifications
                    .Select(s => new SpecificationDto { Key = s.Key, Value = s.Value })
                    .ToList()
            };
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Value,
                Specifications = product.Specifications
                    .Select(s => new SpecificationDto { Key = s.Key, Value = s.Value })
                    .ToList()
            }).ToList();
        }
    }

}
