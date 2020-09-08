using PPM.Printing.Application.Configuration.Commands;
using System.Reflection;

namespace PPM.Printing.Infrastructure.Configuration
{
    internal class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;
    }
}
