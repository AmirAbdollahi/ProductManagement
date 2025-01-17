using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); 
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            var productId = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productDto); 
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest(); 
            }

            try
            {
                await _productService.UpdateProductAsync(productDto);
                return NoContent(); 
            }
            catch (Exception)
            {
                return NotFound(); 
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent(); 
            }
            catch (Exception)
            {
                return NotFound(); 
            }
        }
    }
}
