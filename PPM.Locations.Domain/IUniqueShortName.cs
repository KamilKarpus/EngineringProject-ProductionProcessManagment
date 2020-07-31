namespace PPM.Locations.Domain
{
    public interface IUniqueShortName
    {
        bool IsUnique(string shortName);
    }
}
