using System;
using System.Diagnostics.CodeAnalysis;

namespace PPM.Domain.ValueObject
{
    public struct Percentage : IEquatable<Percentage>
    {
        public int Value { get; private set; }

        public double Fraction { get => Value / 100; }
        public Percentage(int value)
        {
            Value = value;
        }
        public bool Equals([AllowNull] Percentage other)
            => Value == other.Value;

        public static Percentage Of(int value)
            => new Percentage(value);


        public int CompareTo(Percentage other)
        {
            if (Value < other.Value)
            {
                return 1;
            }
            else if (Value > other.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int Compare([AllowNull] Percentage x, [AllowNull] Percentage y)
            => x.CompareTo(y);

        public static Percentage Zero = Percentage.Of(0);
        public static Percentage Max = Percentage.Of(100);

        public static bool operator >(Percentage a, Percentage b)
            => a.Value > b.Value;
        public static bool operator <(Percentage a, Percentage b)
            => a.Value < b.Value;

        public static bool operator ==(Percentage a, Percentage b)
            => a.Value == b.Value;

        public static bool operator !=(Percentage a, Percentage b)
            => a.Value != b.Value;
        
    }
}
