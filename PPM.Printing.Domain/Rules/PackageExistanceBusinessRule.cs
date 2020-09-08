using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Printing.Domain.Exception;
using System;

namespace PPM.Printing.Domain.Rules
{
    public class PackageExistanceBusinessRule : IBusinessRule
    {
        public PPMException Exception => throw new PrintingException("Package doesn't exists", ErrorCodes.PackageDoesntExists);

        private Guid _packageId;
        private IPackageExistance _packageExistance;

        public PackageExistanceBusinessRule(Guid packageId, IPackageExistance packageExistance)
        {
            _packageId = packageId;
            _packageExistance = packageExistance;
        }
        public bool IsBroken()
        {
            return !_packageExistance.PackageExists(_packageId);
        }
    }
}
