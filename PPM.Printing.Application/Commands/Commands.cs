using System;

namespace PPM.Printing.Application.Commands
{
    public class Commands
    {
        public static class V1
        {
            public class RequestPrinting
            {
                public Guid PackageId { get; set;}
            }
        }
    }
}
