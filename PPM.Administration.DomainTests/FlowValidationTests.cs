using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace PPM.Administration.DomainTests
{
    public class FlowValidationTests
    {
        public static ProductionFlow CreateFlow()
        {
            var flow = new ProductionFlow(Guid.NewGuid(), "Name", 40, 1, new LinkedList<Step>());
            flow.AddStep(Guid.NewGuid(), "test1", 5, new Location(Guid.NewGuid(), "Test"), 0);
            flow.AddStep(Guid.NewGuid(), "test2", 5, new Location(Guid.NewGuid(), "Test"), 10);
            flow.AddStep(Guid.NewGuid(), "test6", 10, new Location(Guid.NewGuid(), "Test"), 20);
            flow.AddStep(Guid.NewGuid(), "test4", 3, new Location(Guid.NewGuid(), "Test"), 60);
            flow.AddStep(Guid.NewGuid(), "test5", 7, new Location(Guid.NewGuid(), "Test"), 95);
            flow.AddStep(Guid.NewGuid(), "test6", 10, new Location(Guid.NewGuid(), "Test"), 100);
            return flow;
        }
        [Fact]
        public void FlowValidationTest_IsValid_ShouldRetunTrue()
        {
            var flow = CreateFlow();
            var validator = new ProductionFlowValidator();
            Assert.True(validator.IsValid(flow));
        }

        [Fact]
        public void FlowValidationTest_IsValid_ShouldReturnFalse_When_RequiredDaysAreGreaterThenMaxDays()
        {
            var flow = CreateFlow();
            flow.AddStep(Guid.NewGuid(), "test6", 1, new Location(Guid.NewGuid(), "Test"), 100);
            var validator = new ProductionFlowValidator();
            Assert.False(validator.IsValid(flow));
            Assert.Equal((uint)ErrorCodes.ValidationErrorMaxDaysError, validator.Exception.ExceptionCode);
        }

        [Fact]
        public void FlowValidationTest_IsValid_ShouldReturnFalse_When_MaxPercentageGreaterThenHunderd()
        {
            var flow = CreateFlow();
            flow.AddStep(Guid.NewGuid(), "test6", 1, new Location(Guid.NewGuid(), "Test"), 105);
            var validator = new ProductionFlowValidator();
            Assert.False(validator.IsValid(flow));
            Assert.Equal((uint)ErrorCodes.ValidationErrorMaxPercentage, validator.Exception.ExceptionCode);
        }

        [Fact]
        public void FlowValidationTest_IsValid_ShouldReturnFalse_When_LastStepPercentagteIsNotGreaterThenLastStep()
        {
            var flow = CreateFlow();
            flow.AddStep(Guid.NewGuid(), "test6", 1, new Location(Guid.NewGuid(), "Test"), 95);
            var validator = new ProductionFlowValidator();
            Assert.False(validator.IsValid(flow));
            Assert.Equal((uint)ErrorCodes.ValidationErrorStepPercentage, validator.Exception.ExceptionCode);
        }
    }
}
