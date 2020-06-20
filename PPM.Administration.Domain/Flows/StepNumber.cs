using System;
using System.Diagnostics.CodeAnalysis;

namespace PPM.Administration.Domain.Flows
{
    public struct StepNumber : IEquatable<StepNumber>, IComparable<StepNumber>
    {
        public int Value { get; private set; }
        public StepNumber(int value)
        {
            Value = value;
        }
        public StepNumber GetStepBefore()
        {
            return new StepNumber(Value - 1);
        }
        public StepNumber GetStepAfter()
        {
            return new StepNumber(Value + 1);
        }
        public bool Equals(StepNumber other)
        {
           return Value == other.Value;
        }
        public static StepNumber From(int value)
            => new StepNumber(value);

        public int CompareTo(StepNumber other)
        {
            return Value.CompareTo(other.Value);
        }
        public bool IsFirstStep()
            => Value == 1;
        public bool IsLowerThen(int number)
            => number >= Value;

        public bool isGreaterThen(int number)
         => Value >= number;
        


        public static bool operator ==(StepNumber a, StepNumber b)
           => a.Equals(b);
        public static bool operator !=(StepNumber a, StepNumber b)
             => !a.Equals(b);
    }
}
