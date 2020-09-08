using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PPM.Printing.Domain
{
    public struct PrintingStatus : IEquatable<PrintingStatus>
    {
        private static List<PrintingStatus> _statuses = new List<PrintingStatus>()
        {
            Requested, Failed, Successful
        };
        public int Id { get; private set; }
        public string Name { get; private set; }
        public PrintingStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
       
        public static PrintingStatus Requested => new PrintingStatus(1, nameof(Requested));
        public static PrintingStatus Failed => new PrintingStatus(2, nameof(Failed));
        public static PrintingStatus Successful => new PrintingStatus(3, nameof(Successful));

        public static PrintingStatus Of(int id)
        {
            return _statuses.FirstOrDefault(p => p.Id == id);
        }
        public bool Equals([AllowNull] PrintingStatus other)
        {
            return Id == other.Id;
        }
    }
}