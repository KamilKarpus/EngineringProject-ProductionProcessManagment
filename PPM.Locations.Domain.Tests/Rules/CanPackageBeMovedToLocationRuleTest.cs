using Moq;
using PPM.Locations.Domain.Transfer;
using PPM.Locations.Domain.Transfer.Rules;
using System;
using Xunit;

namespace PPM.Locations.Domain.Tests.Rules
{
    public class CanPackageBeMovedToLocationRuleTest
    {
        private Mock<IGetLocationState> _state;
        public CanPackageBeMovedToLocationRuleTest()
        {
            _state = new Mock<IGetLocationState>();
        }

        [Fact]
        public void Should_be_not_broken()
        {
            _state.Setup(p => p.GetState(It.IsAny<Guid>())).Returns(new LocationState(LocationType.ManyPackageFacalitiles.Id, 10));
            var rule = new CanPackageBeMovedToLocationRule(_state.Object, Guid.NewGuid());
            Assert.False(rule.IsBroken());
        }
        [Fact]
        public void Should_be_broken()
        {
            _state.Setup(p => p.GetState(It.IsAny<Guid>())).Returns(new LocationState(LocationType.OnePackageFacalitiles.Id, 2));
            var rule = new CanPackageBeMovedToLocationRule(_state.Object, Guid.NewGuid());
            Assert.True(rule.IsBroken());
        }

        [Fact]
        public void Should_be_not_broken_when_one_package()
        {
            _state.Setup(p => p.GetState(It.IsAny<Guid>())).Returns(new LocationState(LocationType.OnePackageFacalitiles.Id, 1));
            var rule = new CanPackageBeMovedToLocationRule(_state.Object, Guid.NewGuid());
            Assert.False(rule.IsBroken());
        }
    }
}
