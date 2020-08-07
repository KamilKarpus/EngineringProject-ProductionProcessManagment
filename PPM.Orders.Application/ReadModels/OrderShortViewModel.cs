using System;

namespace PPM.Orders.Application.ReadModels
{
    public class OrderShortViewModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public int OrderYear { get; set; }
    }
}
