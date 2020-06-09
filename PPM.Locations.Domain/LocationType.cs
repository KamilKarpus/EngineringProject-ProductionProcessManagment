using System.Linq;

namespace PPM.Locations.Domain
{
    public class LocationType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private static LocationType[] _types => new LocationType[] { OnePackageFacalitiles, ManyPackageFacalitiles };

        public LocationType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static LocationType OnePackageFacalitiles
            => new LocationType(1, nameof(OnePackageFacalitiles));

        public static LocationType ManyPackageFacalitiles
            => new LocationType(2, nameof(ManyPackageFacalitiles));

        public static LocationType From(int id)
            => _types.FirstOrDefault(p => p.Id == id);
    }
}