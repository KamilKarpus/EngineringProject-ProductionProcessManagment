using PPM.Locations.Domain;
using PPM.Locations.Domain.Flow;
using System.Linq;

namespace PPM.Locations.Infrastructure.Documents.Locations
{
    public static class Extensions
    {
        public static PackageDocument ToDocument(this Package package)
        {
            return new PackageDocument()
            {
                Id = package.Id,
                Height = package.Height.Value,
                Weight = package.Weight.Value,
                Width = package.Width.Value,
                Progress = package.Progress.Value,
                OrderId = package.OrderId,
                Length = package.Length
            };
        }
        
        public static LocationAttributesDocument ToDocument(this LocationAttributes attributes)
        {
            return new LocationAttributesDocument() 
            { 
                IsHandleQrCode =  attributes.IsHandleQrCode
            };

        }
        public static LocationDocument ToDocument(this Location location)
        {
            return new LocationDocument()
            {
                Attributes = location.Attributes?.ToDocument(),
                Height = location.Height.Value,
                Id = location.Id,
                Description = location?.Description,
                Name = location.Name,
                Packages = location.Packages?.Select(p => p.ToDocument()).ToList(),
                ShortName = location.ShortName,
                Type = location.Type.Id,
                Width = location.Width.Value,
                Length = location.Length.Value
            };
        }

        public static LocationAttributes AsEntity(this LocationAttributesDocument attributes)
        {
            return new LocationAttributes(attributes.IsHandleQrCode);
        }  
        public static Package AsEntity(this PackageDocument package)
        {
            return new Package(package.Id, package.Weight, package.Height, package.Width, package.Progress, package.OrderId, package.Length);
        }

        public static Location AsEntity(this LocationDocument location)
        {
            return new Location(location.Id, location.Name, location.Type, location.Description, location.Width, location.Height, location.Attributes.AsEntity(),
                location.ShortName, location.Packages?.Select(p => p.AsEntity()).ToHashSet(), location.Length);
        }
    }
}
