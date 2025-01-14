using ProductManagement.Domain.Enums;

namespace ProductManagement.Domain.ValueObjects
{
    public class Money
    {
        private Money price;

        public decimal Value { get; private set; }

        public Money(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be negative.", nameof(value));

            Value = value;
        }

        public Money(Money price)
        {
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Money other) return false;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
