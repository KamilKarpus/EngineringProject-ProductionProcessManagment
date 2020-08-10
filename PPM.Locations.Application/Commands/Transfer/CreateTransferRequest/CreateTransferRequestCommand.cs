using PPM.Locations.Application.Configuration.Commands;
using System;

namespace PPM.Locations.Application.Commands.Transfer.CreateTransferRequest
{
    public class CreateTransferRequestCommand : ICommand
    { 
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid FromLocationId { get; set; }
        public Guid ToLocationId { get; set; }
        public Guid RequestedByUser { get; set; }
    }
}
