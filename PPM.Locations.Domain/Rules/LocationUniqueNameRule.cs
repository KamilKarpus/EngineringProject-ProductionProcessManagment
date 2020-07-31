using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Locations.Domain.Exceptions;

namespace PPM.Locations.Domain.Rules
{
    public class LocationUniqueNameRule : IBusinessRule
    {
        private readonly IUniqueName _uniqueName;
        private string _name;
        public LocationUniqueNameRule(IUniqueName uniqueName, string name)
        {
            _uniqueName = uniqueName;
            _name = name;
        }
        public PPMException Exception => new LocationException("Location name is taken", ErrorCodes.LocatioNameIsTaken);

        public bool IsBroken()
        {
            return !_uniqueName.IsUnique(_name);
        }
    }
}
