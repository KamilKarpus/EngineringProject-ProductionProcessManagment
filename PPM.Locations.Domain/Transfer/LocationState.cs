namespace PPM.Locations.Domain.Transfer
{
    public class LocationState
    {
        public LocationType Type { get; private set; }
        public int PackageCount { get; private set; }
        public LocationState(int id, int count)
        {
            Type = LocationType.From(id);
            PackageCount = count;
        }
       
    }
}