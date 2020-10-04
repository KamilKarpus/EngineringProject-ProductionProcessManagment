using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Locations.Application.Commands
{
    public static class Commands
    {
        public static class V1 
        {
            public class AddLocation
            {
                public string Name { get; set; }
                public int Type { get; set; }
                public bool HandleQR { get; set; }
                public string Description { get; set; }
                public decimal Height { get; set; }
                public decimal Width { get; set; }
                public string ShortName { get; set; }
                public decimal Length { get; set; }
            }
            public class CreateTransfer
            {
                public Guid PackageId { get; set; }
                public Guid FromLocationId { get; set; }
                public Guid ToLocationId { get; set; }
            }
        }
    }
}
