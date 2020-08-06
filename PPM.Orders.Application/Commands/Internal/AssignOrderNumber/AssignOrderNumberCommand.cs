using PPM.Orders.Application.Configuration.Commands;
using System;

namespace PPM.Orders.Application.Commands.Internal.AssignOrderNumber
{
    public class AssignOrderNumberCommand : ICommand
    { 
        public Guid OrderId { get; set; }
    }
}
