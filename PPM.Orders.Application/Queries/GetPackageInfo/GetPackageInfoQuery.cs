using PPM.Orders.Application.Configuration.Queries;
using System;

namespace PPM.Orders.Application.Queries.GetPackageInfo
{
    public class GetPackageInfoQuery : IQuery<PackageResult>
    {
        public Guid OrderId { get; set; }
        public Guid PackageId { get; set; }
    }
}
