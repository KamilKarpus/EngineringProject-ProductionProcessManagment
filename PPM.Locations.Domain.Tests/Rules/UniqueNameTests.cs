using Moq;
using PPM.Locations.Domain.Rules;
using System;
using Xunit;

namespace PPM.Locations.Domain.Tests.Rules
{
    public class UniqueNameTests
    {
        private Mock<IUniqueName> _uniqueName;
        public UniqueNameTests()
        {
            _uniqueName = new Mock<IUniqueName>();
        }

        [Fact]
        void Rule_Should_Be_Not_Broken()
        {
            _uniqueName.Setup(p => p.IsUnique(It.IsAny<string>())).Returns(true);
            var rule = new LocationUniqueNameRule(_uniqueName.Object, "test");
            Assert.False(rule.IsBroken());        
        }
        [Fact]
        void Rule_Should_Be_Broken()
        {
            _uniqueName.Setup(p => p.IsUnique(It.IsAny<string>())).Returns(false);
            var rule = new LocationUniqueNameRule(_uniqueName.Object, "test");
            Assert.True(rule.IsBroken());
        }
    }
}
