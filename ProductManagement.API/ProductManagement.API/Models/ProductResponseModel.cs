namespace ProductManagement.API.Models
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<SpecificationRequestModel> Specifications { get; set; }
    }
}
