using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PPM.Administration.Domain.Flows
{
    public class Status : IEquatable<Status>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Status Construction => new Status(1, nameof(Construction));
        public static Status ReadyToUse => new Status(2, nameof(ReadyToUse));

        private static Status[] _statuses = new Status[] { Construction, ReadyToUse };

        public static Status From(int id)
            => _statuses.FirstOrDefault(p => p.Id == id);

        public bool Equals([AllowNull] Status other)
        => Id == other.Id;


        public static bool operator ==(Status a, Status b)
            => a.Equals(b);
        public static bool operator !=(Status a, Status b)
             =>!a.Equals(b);
    }
}
