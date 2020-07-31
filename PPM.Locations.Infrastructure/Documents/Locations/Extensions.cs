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
                Name = package.Name,
                Weight = package.Weight.Value,
                Width = package.Width.Value
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
                Width = location.Width.Value
            };
        }

        public static LocationAttributes AsEntity(this LocationAttributesDocument attributes)
        {
            return new LocationAttributes(attributes.IsHandleQrCode);
        }  
        public static Package AsEntity(this PackageDocument package)
        {
            return new Package(package.Id, package.Name, package.Weight, package.Height, package.Width);
        }

        public static Location AsEntity(this LocationDocument location)
        {
            return new Location(location.Id, location.Name, location.Type, location.Description, location.Width, location.Height, location.Attributes.AsEntity(),
                location.ShortName, location.Packages?.Select(p => p.AsEntity()).ToHashSet());
        }
    }
}
