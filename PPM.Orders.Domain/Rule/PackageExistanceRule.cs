using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Orders.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Orders.Domain.Rule
{
    public class PackageExistanceRule : IBusinessRule
    {
        public PPMException Exception => new OrderException("Package doesn't exists", ErrorCode.PackageDoesntExists);

        private readonly HashSet<Package> _packages;
        private readonly Guid _packageId;
        public PackageExistanceRule(HashSet<Package> packages, Guid packageId)
        {
            _packages = packages;
            _packageId = packageId;
        }
        public bool IsBroken()
        {
            var package = _packages.Any(p => p.Id == _packageId);
            return !package;
        }
    }
}
