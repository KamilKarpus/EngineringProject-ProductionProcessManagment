using System;

namespace PPM.Printing.Domain
{
    public interface IPackageExistance
    {
        bool PackageExists(Guid packageId);
    }
}
