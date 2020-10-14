using System;
using System.Threading.Tasks;

namespace PPM.Locations.Domain.Repositories
{
    public interface IPackageProgressRepository
    {
        Task<PackageProgress> GetByPackageId(Guid packageId);
        Task Add(PackageProgress packageProgress);
        Task Update(PackageProgress packageProgress);
    }
}
