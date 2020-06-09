using System;
using System.Diagnostics.CodeAnalysis;

namespace PPM.Domain.ValueObject
{
    public struct Meters : IEquatable<Meters>
    {
        public decimal Value { get; private set; }

        public Meters(decimal value)
        {
            Value = value;
        }
        public static Meters FromDecimal(decimal value) => new Meters(value);

        public static Meters Zero(decimal value) => new Meters(0);

        public static bool operator ==(Meters left, Meters right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Meters left, Meters right)
        {
            return !(left == right);
        }

        public static Meters operator -(Meters left, Meters right)
        {
            return new Meters(left.Value - right.Value);
        }

        public static decimal operator /(Meters left, Meters right)
        {
            return Math.Floor(left.Value / right.Value);
        }

        public static decimal operator /(Meters left, decimal divider)
        {
            return left.Value / divider;
        }

        public override string ToString() => $"{Value} m";


        public bool Equals([AllowNull] Meters other)
            => Value == other.Value;

        public override bool Equals(object obj)
            => this.Equals(obj);

        public override int GetHashCode()
            => Value.GetHashCode();
    }
}
