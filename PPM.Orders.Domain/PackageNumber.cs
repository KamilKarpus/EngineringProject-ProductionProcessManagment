using System;

namespace PPM.Orders.Domain
{
    public struct PackageNumber : IEquatable<PackageNumber>, IComparable<PackageNumber>
    {
        public int Value { get; private set; }

        public PackageNumber(int value)
        {
            Value = value;
        }
        public static PackageNumber First
            => new PackageNumber(1);

        public static PackageNumber Zero
            => new PackageNumber(0);
        public PackageNumber Next()
        {
            return new PackageNumber(Value + 1);
        }
        public int CompareTo(PackageNumber other)
        {
            return Value.CompareTo(other.Value);
        }
        public bool Equals(PackageNumber other)
        {
            return other.Value == Value;
        }
        public static PackageNumber From(int value)
        {
            return new PackageNumber(value);
        }
        public static bool operator ==(PackageNumber a, PackageNumber b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(PackageNumber a, PackageNumber b)
        {
            return !a.Equals(b);
        }
    }
}
