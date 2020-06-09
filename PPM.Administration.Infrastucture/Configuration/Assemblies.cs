using PPM.Administration.Application.Configuration.Commands;
using System.Reflection;

namespace PPM.Administration.Infrastucture.Configuration
{
    internal class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;
    }
}
