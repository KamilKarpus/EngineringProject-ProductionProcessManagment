using System;
namespace PPM.Locations.Domain.Transfer
{
    public interface IPackageExistance
    {
        bool Exists(Guid packageId);
    }
}
