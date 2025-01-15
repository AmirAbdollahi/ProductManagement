using ProductManagement.Domain.Enums;

namespace ProductManagement.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<SpecificationDto> Specifications { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }

}
