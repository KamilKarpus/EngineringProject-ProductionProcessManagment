using PPM.Locations.Application.Configuration.Commands;
using System;

namespace PPM.Locations.Application.Commands.AddLocation
{
    public class AddLocationCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get;  set; }
        public bool HandleQR { get; set; }
        public string Description { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public string ShortName { get; set; }
    }
}
