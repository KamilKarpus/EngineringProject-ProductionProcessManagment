using Moq;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Flows.BusinessRules;
using System;
using System.Collections.Generic;
using Xunit;

namespace PPM.Administration.DomainTests.Rules
{
    public class FirstPositionStepChangedRuleTests
    {
        private List<Step> _steps = new List<Step>()
        {
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test",1),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test2",2),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test3",3),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test4",4)
        };

        private Mock<IFirstLocationSupportPrinting> _supportPrinting;

        public FirstPositionStepChangedRuleTests()
        {
            _supportPrinting = new Mock<IFirstLocationSupportPrinting>();
        }

        [Fact]
        public void Should_Be_Broken()
        {
            _supportPrinting.Setup(p => p.IsSupport(It.IsAny<Guid>())).Returns(false);
            var rule = new FirstStepPostionChangeRule(_supportPrinting.Object, _steps);
            Assert.True(rule.IsBroken());
        }
        [Fact]
        public void Should_Be_Not_Broken()
        {
            _supportPrinting.Setup(p => p.IsSupport(It.IsAny<Guid>())).Returns(true);
            var rule = new FirstStepPostionChangeRule(_supportPrinting.Object, _steps);
            Assert.False(rule.IsBroken());
        }
    }
}
