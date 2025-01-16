namespace ProductManagement.Domain.Entities
{
    public class Specification
    {
        public Guid SpecificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public Specification(string key, string value)
        {
            SpecificationId = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));

            Key = key;
            Value = value;
        }
    }
}
