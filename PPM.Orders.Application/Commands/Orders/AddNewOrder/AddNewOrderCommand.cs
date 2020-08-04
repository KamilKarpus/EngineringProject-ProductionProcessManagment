using PPM.Orders.Application.Configuration.Commands;
using System;

namespace PPM.Orders.Application.Commands.Orders.AddNewOrder
{
    public class AddNewOrderCommand : ICommand
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Guid FlowId { get; set; }
    }
}
