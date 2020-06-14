using PPM.Locations.Application.Configuration.Commands;
using System.Reflection;

namespace PPM.Locations.Infrastructure.Configuration
{
    public class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;
    }
}
