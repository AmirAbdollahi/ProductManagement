namespace ProductManagement.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<SpecificationDto> Specifications { get; set; }
    }
}
