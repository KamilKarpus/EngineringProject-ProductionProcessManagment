using PPM.Application.ModuleClient;
using PPM.Orders.Application.Configuration.Services;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Infrastructure.Services.Model;
using System;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Services
{
    public class LocationsService : ILocationsService
    {
        private string _basePath = "internal/locations";
        private readonly IModuleClient _client;
        public LocationsService(IModuleClient client)
        {
            _client = client;
        }
        public async Task<PackageLocationInfoDTO> GetPackageInfo(Guid packageId)
        {
            return await _client.GetAsync<PackageLocationInfoDTO>(_basePath, String.Empty, new PackageRequestDTO()
            {
                PackageId = packageId
            });
        }
    }
}
