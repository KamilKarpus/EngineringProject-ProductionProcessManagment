using Moq;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Flows.BusinessRules;
using System;
using Xunit;

namespace PPM.Administration.DomainTests.Rules
{
    public class FirstLocationMustSupportPrintingRuleTests
    {
        private Mock<IFirstLocationSupportPrinting> _supportPrinting;

        public FirstLocationMustSupportPrintingRuleTests()
        {
            _supportPrinting = new Mock<IFirstLocationSupportPrinting>();
        }
        [Fact]
        public void Should_Be_Broken()
        {
            _supportPrinting.Setup(p => p.IsSupport(It.IsAny<Guid>())).Returns(false);
            var rule = new FirstLocationMustSupportPrintingRule(1, _supportPrinting.Object, Guid.NewGuid());
            Assert.True(rule.IsBroken());        
        }
        [Fact]
        public void Should_Be_Not_Broken()
        {
            _supportPrinting.Setup(p => p.IsSupport(It.IsAny<Guid>())).Returns(true);
            var rule = new FirstLocationMustSupportPrintingRule(1, _supportPrinting.Object, Guid.NewGuid());
            Assert.False(rule.IsBroken());
        }
    }
}
