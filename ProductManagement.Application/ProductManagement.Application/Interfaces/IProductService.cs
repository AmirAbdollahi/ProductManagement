using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(UpdateProductDto productDto);
        Task DeleteProductAsync(Guid id);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetAllProductsAsync();
    }

}
