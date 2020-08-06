using MongoDB.Driver.Core.Operations;
using System;

namespace PPM.Infrastructure.InternalCommands
{
    public class InternalCommand
    {
        public Guid Id { get; set; }
        public DateTime OccouredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string Error { get; set; }
        public DateTime ProcessedDate { get; set; }

        public InternalCommand(string data, string type)
        {
            Id = Guid.NewGuid();
            OccouredOn = DateTime.Now;
            Type = type;
            Data = data;
        }
    }
}
