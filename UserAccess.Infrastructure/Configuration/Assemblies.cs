using PPM.UserAccess.Application.Configuration.Commands;
using System.Reflection;

namespace PPM.UserAccess.Infrastructure.Configuration
{
    internal class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;
    }
}
