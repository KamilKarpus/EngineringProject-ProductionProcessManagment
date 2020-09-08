using System;
using System.Threading.Tasks;

namespace PPM.Printing.Domain.Repository
{
    public interface IPackageRepository
    {
        Task Add(Package package);
        Task<Package> GetById(Guid id);
    }
}
