using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Flows.BusinessRules;
using System;
using System.Collections.Generic;
using Xunit;

namespace PPM.Administration.DomainTests.Rules
{
    public class StepMustHaveUniqueNameTests
    {
        private List<Step> _steps = new List<Step>()
        {
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test",1),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test2",2),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test3",3),
            new Step(Guid.NewGuid(),Guid.NewGuid(),10,10,"Test4",4)
        };

        [Fact]
        public void Should_Be_Broken()
        {
            var rule = new StepMustHaveUniqueName(_steps, "Test2");
            Assert.True(rule.IsBroken());
        }
        [Fact]
        public void Should_Be_Not_Broken()
        {
            var rule = new StepMustHaveUniqueName(_steps, "Test24");
            Assert.False(rule.IsBroken());
        }
    }
}
