namespace ProductManagement.Domain.Events
{
    public class ProductCreatedEvent
    {
        public Guid ProductId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ProductCreatedEvent(Guid productId)
        {
            ProductId = productId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
