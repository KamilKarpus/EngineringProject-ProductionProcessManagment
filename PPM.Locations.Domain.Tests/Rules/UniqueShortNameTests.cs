using Moq;
using PPM.Locations.Domain.Rules;
using Xunit;

namespace PPM.Locations.Domain.Tests.Rules
{
    public class UniqueShortNameTests
    {
        private Mock<IUniqueShortName> _uniqueShortName;
        public UniqueShortNameTests()
        {
            _uniqueShortName = new Mock<IUniqueShortName>();
        }
        [Fact]
        void Rule_Should_Be_Not_Broken()
        {
            _uniqueShortName.Setup(p => p.IsUnique(It.IsAny<string>())).Returns(true);
            var rule = new LocationUniqueShortNameRule(_uniqueShortName.Object, "test");
            Assert.False(rule.IsBroken());
        }
        [Fact]
        void Rule_Should_Be_Broken()
        {
            _uniqueShortName.Setup(p => p.IsUnique(It.IsAny<string>())).Returns(false);
            var rule = new LocationUniqueShortNameRule(_uniqueShortName.Object, "test");
            Assert.True(rule.IsBroken());
        }
    }
}
