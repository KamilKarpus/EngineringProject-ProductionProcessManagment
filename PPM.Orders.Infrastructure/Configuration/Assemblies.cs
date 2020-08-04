using PPM.Orders.Application.Configuration.Commands;
using System.Reflection;

namespace PPM.Orders.Infrastructure.Configuration
{
    internal class Assemblies
    {
        public static readonly Assembly Application = typeof(ICommand).Assembly;
    }
}
