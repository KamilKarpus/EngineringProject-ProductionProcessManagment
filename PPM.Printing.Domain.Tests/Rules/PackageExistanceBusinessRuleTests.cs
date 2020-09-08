using Moq;
using PPM.Printing.Domain.Rules;
using System;
using Xunit;

namespace PPM.Printing.Domain.Tests.Rules
{
    public class PackageExistanceBusinessRuleTests
    {
        private readonly Mock<IPackageExistance> _packageExistance;

        public PackageExistanceBusinessRuleTests()
        {
            _packageExistance = new Mock<IPackageExistance>();
        }
        [Fact]
        public void Rule_Should_Be_Broke()
        {
            _packageExistance.Setup(p => p.PackageExists(It.IsAny<Guid>()))
                .Returns(false);

            var rule = new PackageExistanceBusinessRule(Guid.NewGuid(), _packageExistance.Object);
            Assert.True(rule.IsBroken());
        }

        [Fact]
        public void Rule_Should_Be_Not_broken()
        {
            _packageExistance.Setup(p => p.PackageExists(It.IsAny<Guid>()))
         .Returns(true);

            var rule = new PackageExistanceBusinessRule(Guid.NewGuid(), _packageExistance.Object);
            Assert.False(rule.IsBroken());
        }
    }
}
