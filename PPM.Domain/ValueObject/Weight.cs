namespace PPM.Domain.ValueObject
{
    public struct Kilograms
    {
        public decimal Value { get; private set; }

        public Kilograms(decimal value)
        {
            Value = value;
        }
        public static Kilograms FromDecimal(decimal value)
            => new Kilograms(value);
    }
}
