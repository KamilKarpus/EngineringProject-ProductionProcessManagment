namespace PPM.Locations.Domain
{
    public interface IUniqueName
    {
        bool IsUnique(string name);
    }
}
