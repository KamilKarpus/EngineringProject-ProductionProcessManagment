using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Locations.Domain.Exceptions;

namespace PPM.Locations.Domain.Rules
{
    public class LocationUniqueShortNameRule : IBusinessRule
    {
        private readonly IUniqueShortName _uniqueShortName;
        private readonly string _shortName;
        public LocationUniqueShortNameRule(IUniqueShortName uniqueShortName, string shortName)
        {
            _uniqueShortName = uniqueShortName;
            _shortName = shortName;
        }

        public PPMException Exception => new LocationException("Shortname must be unique", ErrorCodes.LocationShortNameUnique);

        public bool IsBroken()
        {
            return !_uniqueShortName.IsUnique(_shortName);
        }
    }
}
