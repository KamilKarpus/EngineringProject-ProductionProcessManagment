using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Orders.Application.ReadModels
{
    public class PrintingDTO
    {
        public Guid PackageId { get; set; }
        public string FileUrl { get; set; }
    }
}
