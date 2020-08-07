using PPM.Orders.Application.Configuration.Commands;
using System;

namespace PPM.Orders.Application.Commands.Orders.AddPackage
{
    public class AddPackageCommand : ICommand
    {
        public Guid PackageId { get; set; }
        public Guid FlowId { get; set; }
        public decimal Weight {get; set;}
        public decimal Height {get; set;}
        public decimal Width {get; set;}
        public Guid OrderId { get; set; }
    }
}
