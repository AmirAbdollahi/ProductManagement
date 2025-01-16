namespace ProductManagement.API.Models
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<SpecificationRequestModel> Specifications { get; set; }
    }
}
