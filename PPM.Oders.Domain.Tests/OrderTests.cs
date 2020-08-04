using PPM.Domain.ValueObject;
using PPM.Orders.Domain;
using System;
using System.Linq;
using Xunit;

namespace PPM.Oders.Domain.Tests
{
    public class PackageTests
    {
        private readonly Order _order;
        public PackageTests()
        {
            _order = Order.Create(Guid.NewGuid(), "Test", DateTime.Now, new ProductionFlow(Guid.NewGuid(), "Test"));
        }
        [Fact]
        public void Order_AddPackage_Package_Should_Have_Initial_Value()
        {
            var packageId = Guid.NewGuid();
            _order.AddPackage(packageId, Kilograms.FromDecimal(100), Meters.FromDecimal(100), Meters.FromDecimal(50));
            var package = _order.Packages.FirstOrDefault(p => p.Id == packageId);
            Assert.Equal(package.Number, PackageNumber.First);
        }
        [Fact]
        public void Order_AddMany_Packages_Should_Packages_Should_Be_Numbered_Asceding()
        {

            _order.AddPackage(Guid.NewGuid(), Kilograms.FromDecimal(100), Meters.FromDecimal(100), Meters.FromDecimal(50));
            _order.AddPackage(Guid.NewGuid(), Kilograms.FromDecimal(100), Meters.FromDecimal(100), Meters.FromDecimal(50));
            _order.AddPackage(Guid.NewGuid(), Kilograms.FromDecimal(100), Meters.FromDecimal(100), Meters.FromDecimal(50));
            _order.AddPackage(Guid.NewGuid(), Kilograms.FromDecimal(100), Meters.FromDecimal(100), Meters.FromDecimal(50));
            Assert.Collection(_order.Packages, item => Assert.Equal(PackageNumber.First, item.Number),
                                               item => Assert.Equal(new PackageNumber(2), item.Number),
                                               item => Assert.Equal(new PackageNumber(3), item.Number),
                                               item => Assert.Equal(new PackageNumber(4), item.Number));
        }

    }
}
