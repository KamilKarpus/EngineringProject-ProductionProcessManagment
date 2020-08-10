using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PPM.Locations.Domain
{
    public struct TransferStatus : IEquatable<TransferStatus>
    {
        public static TransferStatus[] Statuses = {InProgress, Completed};
        public const int InProgressId = 1;
        public const int CompletedId = 2;
        public int Id { get; private set; }
        public string Name { get; private set; }

        public TransferStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public static TransferStatus InProgress => new TransferStatus(InProgressId, nameof(InProgress));
        public static TransferStatus Completed => new TransferStatus(CompletedId, nameof(Completed));

        public static TransferStatus From(int id)
        {
            return Statuses.FirstOrDefault(p => p.Id == id);
        }
        public bool Equals([AllowNull] TransferStatus other)
        {
            return Id == other.Id;
        }
        public static bool operator==(TransferStatus a, TransferStatus b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(TransferStatus a, TransferStatus b)
        {
            return a!.Equals(b);
        }
    }
}