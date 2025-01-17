using Newtonsoft.Json;
using ProductManagement.Application.DTOs;
using Shouldly;
using System.Text;

namespace ProductManagement.Tests.Integration
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProductControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClientWithInMemoryDb();
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnCreatedResponse()
        {
            // Arrange
            var newProduct = new CreateProductDto
            {
                Name = "Test Product",
                Price = 100.00M,
                ProductCategory = Domain.Enums.ProductCategory.Furniture
            };

            // Act
            var response = await _client.PostAsync("/api/products",
                new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Created);

            // Assert
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.ShouldContain("Test Product");
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnOkResponse()
        {
            // Act
            var response = await _client.GetAsync("/api/products");

            // Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);

            // Assert
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.ShouldContain("Test Product"); 
        }

    }
}
