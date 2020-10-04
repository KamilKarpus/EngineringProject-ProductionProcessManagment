using Moq;
using PPM.Printing.Domain.Rules;
using System;
using Xunit;

namespace PPM.Printing.Domain.Tests.Rules
{
    public class PackageExistanceBussinessRuleTests
    {
        private readonly Mock<IPrintingRequestExistance> _existance;
        public PackageExistanceBussinessRuleTests()
        {
            _existance = new Mock<IPrintingRequestExistance>();
        }

        [Fact]
        public void Rule_Should_Be_Broken()
        {
            _existance.Setup(p => p.WasPrintingRequested(It.IsAny<Guid>())).Returns(true);
            var rule = new PrintingRequestExistanceRule(_existance.Object, Guid.NewGuid());
            Assert.True(rule.IsBroken());
        }

        [Fact]
        public void Rule_Should_Be_Not_Broken()
        {
            _existance.Setup(p => p.WasPrintingRequested(It.IsAny<Guid>())).Returns(false);
            var rule = new PrintingRequestExistanceRule(_existance.Object, Guid.NewGuid());
            Assert.False(rule.IsBroken());
        }

    }
}
