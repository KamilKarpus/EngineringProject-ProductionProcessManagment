using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System;

namespace PPM.Locations.Application.Queries.PackageInfo
{
    public class GetPackageInfoQuery : IQuery<PackageInfoReadModel>
    {
        public Guid PackageId { get; set; }
    }
}
