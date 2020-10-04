using PPM.Orders.Application.ReadModels;
using System;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Configuration.Services
{
    public interface ILocationsService
    {
        Task<PackageLocationInfoDTO> GetPackageInfo(Guid packageId);
    }
}
